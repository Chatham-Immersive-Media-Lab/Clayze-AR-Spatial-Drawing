using System;
using UnityEngine;


	public class DepthInput : MonoBehaviour
	{
		private PenInput3D _penInput3D;
		public Transform _drawDepthUpdatedObject;
		public float minDrawDepth;
		public float maxDrawDepth;

		private float layerSeperation = 1f;

		private void Awake()
		{
			_penInput3D = GetComponent<PenInput3D>();
		}

		private void Update()
		{
			SetDrawDepth(_drawDepthUpdatedObject.transform.position.z);
		}

		public void SetDrawDepth(float depth)
		{
			_penInput3D.DrawDepth = Mathf.Clamp(depth, minDrawDepth, maxDrawDepth);
		}
		
		
	}
