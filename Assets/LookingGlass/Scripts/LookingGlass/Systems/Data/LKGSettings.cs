using LookingGlass.Toolkit;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace LookingGlass {
    public struct LKGSettings {
        public static LKGSettings Default => new() {
            loggingFlags = BridgeLoggingFlags.All,
            queryingLoggingFlags = BridgeLoggingFlags.Timing,
            enableHologramDebugging = false,
#if ENABLE_INPUT_SYSTEM
            hologramDebuggingKeys = new Key[] {
                Key.LeftCtrl,
                Key.LeftAlt,
                Key.LeftShift
            }
#endif
        };

        public BridgeLoggingFlags loggingFlags;
        public BridgeLoggingFlags queryingLoggingFlags;
        public bool enableHologramDebugging;
#if ENABLE_INPUT_SYSTEM
        public Key[] hologramDebuggingKeys;
#endif
    }
}
