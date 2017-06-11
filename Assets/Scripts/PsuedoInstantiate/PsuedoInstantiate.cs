using UnityEngine;
using System.Collections;

public class PsuedoInstantiate : MonoBehaviour {
	public MeshData m_meshData{ get; set;}

	public void Init() {
		m_meshData = new MeshData ();
		m_meshData.mesh = GetComponent<MeshFilter> ().mesh;
		if(m_meshData == null) {
			MeshFilter filter = this.gameObject.AddComponent<MeshFilter> ();
			m_meshData.mesh = filter.mesh;
		}
	}

	public void UpdateMesh() {
		m_meshData.UpdateMesh ();
	}
}
