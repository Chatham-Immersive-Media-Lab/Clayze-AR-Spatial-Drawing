using UnityEngine;

namespace Clayze.Ink.Input
{
	public class DepthInput : MonoBehaviour
	{
		private PenInput3D _penInput3D;

		public float minDrawDepth;
		public float maxDrawDepth;

		private float layerSeperation = 1f;
		public void SetDrawDepth(float depth)
		{
			_penInput3D.drawDepth = Mathf.Clamp(depth, minDrawDepth, maxDrawDepth);
		}

		public void PullForward()
		{
			SetDrawDepth(_penInput3D.drawDepth+layerSeperation);
		}

		public void PushBackward()
		{
			SetDrawDepth(_penInput3D.drawDepth-layerSeperation);
		}

		public float GetCurrentDrawDepth()
		{
			return _penInput3D.drawDepth;
		}
	}
}