using System;
using UnityEngine;


public class PenPreviewPositionUpdater : MonoBehaviour
{
	public PenInput3D _PenInput3D;

	private void Awake()
	{
		if (_PenInput3D == null)
		{
			_PenInput3D = GameObject.FindObjectOfType<PenInput3D>();
		}
	}

	private void Update()
	{
		transform.position = _PenInput3D.PenToWorld();
	}
}
