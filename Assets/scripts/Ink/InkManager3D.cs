using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clayze.Ink
{
	public class InkManager3D : MonoBehaviour
	{
		public Action<Stroke3> OnNewStroke;
		
		private bool _canAdd = true;
		private byte _lastPenID = 0;
		private Stroke3[] _activeStrokes = new Stroke3[255];
		
		public byte GetUniquePenID()
		{
			_lastPenID++;
			return _lastPenID;
		}

		public Stroke3 StartStroke(byte pen, bool local, Color color, float thickness = 1)
		{
			var s = new Stroke3(this, pen, local, thickness, color);
			_activeStrokes[pen] = s;
			OnNewStroke?.Invoke(s);
			return s;
		}
		
	}
}