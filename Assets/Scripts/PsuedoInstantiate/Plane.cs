using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plane : PsuedoInstantiate {

	public List<Primitive> planes{ get; set; }

	// 8125(plane)/2730(cube)

	void Awake() {
		base.Init ();
		planes = new List<Primitive> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void CreatePlane(Vector3 pos, Vector3 col, Vector3 eulerAngles) {
		float x = pos.x*0.5f;
		float y = pos.y*0.5f;
		float z = pos.z*0.5f;

		int start = m_meshData.vertices.Count;

		Primitive p = new Primitive ();
		p.pivot = new Vector3 (x,y,z);
		p.offset = pos;
		p.pos = pos;

		m_meshData.vertices.Add(new Vector3 (x-0.5f,  y,  z + 0.5f ));
		m_meshData.vertices.Add(new Vector3 (x + 0.5f, y,  z + 0.5f ));
		m_meshData.vertices.Add(new Vector3 (x + 0.5f, y,  z-0.5f));
		m_meshData.vertices.Add(new Vector3 (x-0.5f,  y,  z-0.5f));

		m_meshData.faceColors.Add(new Color (col.x, col.y, col.z));
		m_meshData.faceColors.Add(new Color (col.x, col.y, col.z));
		m_meshData.faceColors.Add(new Color (col.x, col.y, col.z));
		m_meshData.faceColors.Add(new Color (col.x, col.y, col.z));

		m_meshData.indices.Add(m_meshData.faceCount * 4  ); //1
		m_meshData.indices.Add(m_meshData.faceCount * 4 + 1 ); //2
		m_meshData.indices.Add(m_meshData.faceCount * 4 + 2 ); //3
		m_meshData.indices.Add(m_meshData.faceCount * 4  ); //1
		m_meshData.indices.Add(m_meshData.faceCount * 4 + 2 ); //3
		m_meshData.indices.Add(m_meshData.faceCount * 4 + 3 ); //4

		m_meshData.uvs.Add (new Vector2 (0f, 0f));
		m_meshData.uvs.Add (new Vector2 (1f, 0f));
		m_meshData.uvs.Add (new Vector2 (1f, 1f));
		m_meshData.uvs.Add (new Vector2 (0f, 1f));

		m_meshData.faceCount++;

		Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
		for(int i = start; i<m_meshData.vertices.Count; i++) {
			p.vertices.Add (m_meshData.vertices [i]);
			p.vind.Add (i);
			m_meshData.vertices[i] = (rotation * (m_meshData.vertices[i] - p.pivot) + p.offset);
		}

		p.angle = eulerAngles;
		planes.Add (p);
	}

	public Primitive GetPlane(int targetIndex) {
		return planes[targetIndex];
	}

	public void UpdatePlanePosition(int targetIndex, Vector3 pos) {
		GetPlane(targetIndex).UpdatePosition (m_meshData.vertices, pos);
	}

	public void UpdatePlaneRotation(int targetIndex, Vector3 eulerAngles) {
		GetPlane(targetIndex).UpdateRotation (m_meshData.vertices, eulerAngles);
	}

	public void UpdatePlaneScale(int targetIndex, Vector3 scale) {
		GetPlane(targetIndex).UpdateScale (m_meshData.vertices, scale);
	}
}
