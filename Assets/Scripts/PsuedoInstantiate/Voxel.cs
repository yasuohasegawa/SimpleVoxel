using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SimpleVoxel {
	public class Voxel : PsuedoInstantiate {
		[SerializeField] private float m_texUnit = 0.25f;

		public List<Primitive> blocks{ get; set; }

		// 8125(plane)/2730(cube)

		void Awake() {
			base.Init ();
			blocks = new List<Primitive> ();
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {

		}
			
		private void _CreateCube(Vector3 pos, Vector3 col, Vector3 eulerAngles, Vector2? uvtop = null, Vector2? uvother = null) {
			float x = pos.x*0.5f;
			float y = pos.y*0.5f;
			float z = pos.z*0.5f;

			int start = m_meshData.vertices.Count;

			Vector2 top = Vector2.zero;
			if(uvtop != null){
				top = (Vector2)uvtop;
			}

			Vector2 other = Vector2.zero;
			if(uvother != null){
				other = (Vector2)uvother;
			}

			Primitive block = new Primitive ();
			block.pivot = new Vector3 (x,y,z);
			block.offset = pos;
			block.pos = pos;

			// top
			m_meshData.vertices.Add(new Vector3 (x-0.5f,  y+0.5f,  z + 0.5f ));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y+0.5f,  z + 0.5f ));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y+0.5f,  z-0.5f));
			m_meshData.vertices.Add(new Vector3 (x-0.5f,  y+0.5f,  z-0.5f));

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

			// This is not what I expected... I'll fix this as soon as I figure it out...
			if (uvtop != null) {
				m_meshData.uvs.Add (new Vector2 (m_texUnit * top.x, 2.0f - m_texUnit * top.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * top.x + m_texUnit, 2.0f - m_texUnit * top.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * top.x + m_texUnit, 2.0f - (m_texUnit * top.y + m_texUnit)));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * top.x, 2.0f - (m_texUnit * top.y + m_texUnit)));
			}
			m_meshData.faceCount++;

			// back
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y-0.5f, z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y+0.5f, z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x-0.5f, y+0.5f, z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x-0.5f, y-0.5f, z + 0.5f));

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

			if (uvother != null) {
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - (m_texUnit * other.y + m_texUnit)));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - (m_texUnit * other.y + m_texUnit)));
			}

			m_meshData.faceCount++;

			// right
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y - 0.5f, z-0.5f));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y + 0.5f, z-0.5f));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y + 0.5f, z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y - 0.5f, z + 0.5f));

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

			if (uvother != null) {
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - (m_texUnit * other.y + m_texUnit)));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - (m_texUnit * other.y + m_texUnit)));
			}
			m_meshData.faceCount++;

			// front
			m_meshData.vertices.Add(new Vector3 (x-0.5f, y - 0.5f, z - 0.5f));
			m_meshData.vertices.Add(new Vector3 (x-0.5f, y+0.5f, z - 0.5f));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y+0.5f, z - 0.5f));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));

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

			if (uvother != null) {
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - (m_texUnit * other.y + m_texUnit)));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - (m_texUnit * other.y + m_texUnit)));
			}
			m_meshData.faceCount++;

			// left
			m_meshData.vertices.Add(new Vector3 (x - 0.5f, y - 0.5f, z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x - 0.5f, y + 0.5f, z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));
			m_meshData.vertices.Add(new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));

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

			if (uvother != null) {
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - (m_texUnit * other.y + m_texUnit)));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - (m_texUnit * other.y + m_texUnit)));
			}
			m_meshData.faceCount++;

			// bottom
			m_meshData.vertices.Add(new Vector3 (x-0.5f,  y-0.5f,  z-0.5f ));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y-0.5f,  z-0.5f ));
			m_meshData.vertices.Add(new Vector3 (x + 0.5f, y-0.5f,  z + 0.5f));
			m_meshData.vertices.Add(new Vector3 (x-0.5f,  y-0.5f,  z + 0.5f));

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

			if (uvother != null) {
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - m_texUnit * other.y));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x + m_texUnit, 2.0f - (m_texUnit * other.y + m_texUnit)));
				m_meshData.uvs.Add (new Vector2 (m_texUnit * other.x, 2.0f - (m_texUnit * other.y + m_texUnit)));
			}
			m_meshData.faceCount++;

			Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
			for(int i = start; i<m_meshData.vertices.Count; i++) {
				block.vertices.Add (m_meshData.vertices [i]);
				block.vind.Add (i);
				m_meshData.vertices[i] = (rotation * (m_meshData.vertices[i] - block.pivot) + block.offset);
			}

			block.angle = eulerAngles;
			blocks.Add (block);
		}

		// if you want to use vertex color, please use this one. 
		public void CreateCube(Vector3 pos, Vector3 col, Vector3 eulerAngles) {
			_CreateCube (pos, col, eulerAngles, null, null);
		}

		// if you like "MineCraft" way, please use this one.
		public void CreateCube(Vector3 pos, Vector3 col, Vector3 eulerAngles, Vector2 uvtop, Vector2 uvother){
			_CreateCube (pos, col, eulerAngles, uvtop, uvother);
		}

		// if you want to wrap same texture around cube, please use this one. 
		public void CreateCube(Vector3 pos, Vector3 col, Vector3 eulerAngles, Vector2 all) {
			_CreateCube (pos, col, eulerAngles, all, all);
		}

		public Primitive GetBlock(int targetIndex) {
			return blocks[targetIndex];
		}

		public void UpdateBlockPosition(int targetIndex, Vector3 pos) {
			GetBlock(targetIndex).UpdatePosition (m_meshData.vertices, pos);
		}

		public void UpdateBlockRotation(int targetIndex, Vector3 eulerAngles) {
			GetBlock(targetIndex).UpdateRotation (m_meshData.vertices, eulerAngles);
		}

		public void UpdateBlockScale(int targetIndex, Vector3 scale) {
			GetBlock(targetIndex).UpdateScale (m_meshData.vertices, scale);
		}
	}
}