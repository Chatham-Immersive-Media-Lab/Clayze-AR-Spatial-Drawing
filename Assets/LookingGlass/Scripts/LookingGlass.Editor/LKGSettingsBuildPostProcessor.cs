using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace LookingGlass.Editor {
    public class LKGSettingsBuildPostProcessor : IPostprocessBuildWithReport {
        public int callbackOrder => 0;

        public void OnPostprocessBuild(BuildReport report) {
            if (File.Exists(LKGSettingsSystem.FileName)) {
                string folder = report.summary.outputPath;
                if (!Directory.Exists(folder))
                    folder = Path.GetDirectoryName(folder);
                folder = folder.Replace('\\', '/');

                string outFilePath = Path.Combine(folder, LKGSettingsSystem.FileName).Replace('\\', '/');
                File.Copy(LKGSettingsSystem.FileName, outFilePath, true);
            }
        }
    }
}
