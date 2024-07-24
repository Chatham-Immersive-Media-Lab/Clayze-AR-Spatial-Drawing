using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace LookingGlass {
    public static class LKGSettingsSystem {
        [ExecuteAlways]
        private class BehaviourEvents : MonoBehaviour {
            public event Action onUpdate;

            private void Update() {
                onUpdate();
            }
        }

        public const string FileName = "lkg-settings.json";
        private static object syncRoot = new();
        private static FileSystemWatcher fileWatcher;
        private static bool isDirty = false;
        private static BehaviourEvents events;
        private static LKGSettings settings = LKGSettings.Default;

        public static LKGSettings Settings => settings;

        internal static void InitializeSystem() {
            events = new GameObject(nameof(LKGSettingsSystem) + " Behaviour").AddComponent<BehaviourEvents>();
            events.gameObject.hideFlags = HideFlags.HideAndDontSave;
            events.onUpdate += OnUpdate;

#if HAS_NEWTONSOFT_JSON
            if (File.Exists(FileName)) {
                string fileText = File.ReadAllText(FileName);
                settings = UnityNewtonsoftJSONSerializer.Deserialize<LKGSettings>(fileText);
            }
#else
            settings = LKGSettings.Default;
#endif

            string folderPath = Path.GetDirectoryName(FileName);

            if (string.IsNullOrEmpty(folderPath))
                folderPath = Environment.CurrentDirectory;

            string fileName = Path.GetFileName(FileName);
            fileWatcher = new(folderPath, fileName);
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.Changed += OnFileChanged;
        }

        internal static void UninitializeSystem() {
            if (events != null)
                GameObject.DestroyImmediate(events);

            if (fileWatcher != null) {
                fileWatcher.Dispose();
                fileWatcher = null;
            }
        }

        private static void OnUpdate() {
            bool shouldUpdate = false;
            lock (syncRoot) {
                shouldUpdate = isDirty;
                isDirty = false;
            }

            if (shouldUpdate) {
                ApplySettings();
            }

#if ENABLE_INPUT_SYSTEM
            if (settings.enableHologramDebugging) {
                if (!HologramDebugSnapshots.IsBusy()) {
                    Key[] keys = settings.hologramDebuggingKeys;
                    if (keys != null && keys.Length >= 1) {
                        Keyboard keyboard = InputSystem.GetDevice<Keyboard>();
                        if (keyboard != null) {
                            if (keyboard[keys[keys.Length - 1]].wasPressedThisFrame) {
                                bool allPressed = true;
                                for (int i = 0; i < keys.Length - 1; i++) {
                                    if (!keyboard[keys[i]].isPressed) {
                                        allPressed = false;
                                        break;
                                    }
                                }
                                if (allPressed) {
                                    HologramDebugSnapshots.SaveSnapshots();
                                }
                            }
                        }
                    }
                }
            }
#endif
        }

        private static void ApplySettings() {
            LKGSettings settings = LKGSettingsSystem.settings;
#if HAS_NEWTONSOFT_JSON
            Debug.Log("ApplySettings(" + UnityNewtonsoftJSONSerializer.Serialize(settings, true) + ")");
            LKGDisplaySystem.BridgeConnection.LoggingFlags = settings.loggingFlags;
#endif
        }

        private static void OnFileChanged(object sender, FileSystemEventArgs e) {
            _ = UpdateCalibrationAfterChanged(e.FullPath);
        }

        private static async Task UpdateCalibrationAfterChanged(string filePath) {
#if HAS_NEWTONSOFT_JSON
            string text = await File.ReadAllTextAsync(filePath);
            lock (syncRoot) {
                isDirty = true;
                settings = UnityNewtonsoftJSONSerializer.Deserialize<LKGSettings>(text);
            }
#endif
        }
    }
}
