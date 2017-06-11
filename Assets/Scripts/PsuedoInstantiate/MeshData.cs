using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Unity Mesh class can not extends.
public class MeshData {
	public Mesh mesh{ get; set; }
	public List<Vector3> vertices{ get; set; }
	public List<int> indices{ get; set; }
	public List<Vector2> uvs{ get; set; }
	public List<Color> faceColors{ get; set; }

	public int faceCount{ get; set; }

	public MeshData() {
		Init ();
	}

	public void Init() {
		vertices = new List<Vector3>();
		indices = new List<int>();
		uvs = new List<Vector2>();
		faceColors = new List<Color>();
		faceCount = 0;		
	}

	public void UpdateMesh() {
		mesh.Clear ();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = indices.ToArray();
		if (uvs.Count >= 1) {
			mesh.uv = uvs.ToArray ();
		}
		mesh.colors = faceColors.ToArray();

		mesh.Optimize ();
		mesh.RecalculateNormals ();
		mesh.RecalculateBounds ();
	}
}
