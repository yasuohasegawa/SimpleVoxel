using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This Primitive class holds its own vertices and can update rotation or position.
public class Primitive {
	public List<Vector3> vertices{ get; set; }
	public List<int> vind{ get; set; }

	public Vector3 angle{ get; set; }
	public Vector3 pos{ get; set; }
	public Vector3 pivot{ get; set; }
	public Vector3 offset{ get; set; }
	public Vector3 scale{ get; set; }

	public Primitive() {
		Init ();
	}

	public void Init () {
		vertices = new List<Vector3>();
		vind = new List<int>();
		angle = Vector3.zero;
		pos = Vector3.zero;
		pivot = Vector3.zero;
		offset = Vector3.zero;
		scale = new Vector3(1f,1f,1f);
	}

	public void UpdatePosition(List<Vector3> verts, Vector3 _pos) {
		pos = _pos;
		UpdateTransform (verts);
	}

	public void UpdateRotation(List<Vector3> verts, Vector3 _eulerAngles) {
		angle = _eulerAngles;
		UpdateTransform (verts);
	}

	public void UpdateScale(List<Vector3> verts, Vector3 _scale) {
		scale = _scale;
		UpdateTransform (verts);
	}

	private void UpdateTransform(List<Vector3> verts) {
		Quaternion rotation = Quaternion.Euler(angle.x, angle.y, angle.z);
		for(int i = 0; i<vind.Count; i++) {
			verts[vind[i]] = (rotation * (Vector3.Scale (vertices [i], scale) - pivot) + pos);
		}
	}
}