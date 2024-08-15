using System;
using LookingGlass;
using UnityEngine;
using UnityEngine.InputSystem;


public class DepthInput : MonoBehaviour
	{
		private PenInput3D _penInput3D;
		public Transform _drawDepthUpdatedObject;
		public float minDrawDepth;
		public float maxDrawDepth;
		
		[SerializeField] private Vector2 worldOffsetXY = Vector2.zero;
		[SerializeField] private float worldScaleMultiplier = 1;
		private float layerSeperation = 1f;

		private void Awake()
		{
			_penInput3D = GetComponent<PenInput3D>();
		}

		private void Update()
		{
			//SetDrawDepth(_drawDepthUpdatedObject.transform.position.z);
			transform.position = GetWorldPos();
		}

		public void SetDrawDepth(float depth)
		{
			//_penInput3D.DrawDepth = Mathf.Clamp(depth, minDrawDepth, maxDrawDepth);
		}

		public Vector3 GetWorldPos()
		{
			Vector2 normalizedPen = new Vector2(
				Pen.current.position.x.value / Screen.width * HologramCamera.Instance.Calibration.screenW,
				Pen.current.position.y.value / Screen.height * HologramCamera.Instance.Calibration.screenH /
				HologramCamera.Instance.Calibration.ScreenAspect);
			normalizedPen = normalizedPen / HologramCamera.Instance.Calibration.dpi;
			// normalizedPen = normalizedPen * 2;
			normalizedPen = normalizedPen - new Vector2(
				HologramCamera.Instance.Calibration.ScreenAspect *
				HologramCamera.Instance.CameraProperties.Size,
				HologramCamera.Instance.CameraProperties.Size);
			normalizedPen = (normalizedPen - worldOffsetXY) * worldScaleMultiplier;
			// var penCord = HologramCamera.Instance.SingleViewCamera.ScreenToWorldPoint(new Vector3(Pen.current.position.x.value, Pen.current.position.y.value,DrawDepth));
			return new Vector3(normalizedPen.x, normalizedPen.y, _drawDepthUpdatedObject.transform.position.z);
			//could draw-depth by a 0->1 relationship between near and far clip plane?
		}
		
	}
