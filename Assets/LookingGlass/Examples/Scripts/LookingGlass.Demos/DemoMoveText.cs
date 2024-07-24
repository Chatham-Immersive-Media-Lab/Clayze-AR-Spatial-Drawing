//Copyright 2017-2021 Looking Glass Factory Inc.
//All rights reserved.
//Unauthorized copying or distribution of this file, and the source code contained herein, is strictly prohibited.

using UnityEngine;
using UnityEngine.UI;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace LookingGlass.Demos {
    public class DemoMoveText : MonoBehaviour {
        [SerializeField] private HologramCamera hologramCamera;
        [SerializeField] private Text label;
        [SerializeField] private Text textThatMoves;

        private float whenToStartAutomating;
        private float amountForward;

        private void Start() {
            textThatMoves.text = "This text is moving";
            whenToStartAutomating = 0;
        }

        private void Update() {
            bool up = false;
            bool down = false;

#if ENABLE_INPUT_SYSTEM
            Keyboard keyboard = InputSystem.GetDevice<Keyboard>();
            if (keyboard != null) {
                if (keyboard.upArrowKey.isPressed)
                    up = true;
                if (keyboard.downArrowKey.isPressed)
                    down = true;
            }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
            if (Input.GetKey(KeyCode.UpArrow))
                up = true;
            if (Input.GetKey(KeyCode.DownArrow))
                down = true;
#endif

            if (up) {
                amountForward = amountForward + 0.1f;
                whenToStartAutomating = Time.time + 2;
            } else if (down) {
                amountForward = amountForward - 0.1f;
                whenToStartAutomating = Time.time + 2;
            }

            if (Time.time > whenToStartAutomating) {
                amountForward = Mathf.Sin(Time.time) * 5f;
            }

            Vector3 textPosition = textThatMoves.transform.localPosition;
            textPosition.z = amountForward;
            textThatMoves.transform.localPosition = textPosition;

            label.text = "Units from plane of convergence: " + amountForward.ToString("F1");

            HologramCameraProperties cameraData = hologramCamera.CameraProperties;
            float size = cameraData.Size;
            float nearClipAmount = size * cameraData.NearClipFactor * -1;
            float farClipAmount = size * cameraData.FarClipFactor;

            if (amountForward < nearClipAmount || amountForward > farClipAmount) {
                label.text += "\n(beyond the clipping plane)";
            }
        }
    }
}
