using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelTest : MonoBehaviour {
	private SimpleVoxel.Voxel m_voxel;
	private float m_debugYFrameCount = 0f;

	// Use this for initialization
	void Start () {
		m_voxel = gameObject.GetComponent<SimpleVoxel.Voxel> ();

		m_voxel.CreateCube(new Vector3(0f,0f,0f),new Vector3(255f,0f,255f),Vector3.zero);
		m_voxel.CreateCube(new Vector3(0f,0f,1f),new Vector3(255f,0f,255f),Vector3.zero);
		m_voxel.CreateCube(new Vector3(1f,1f,0f),new Vector3(255f,255f,0f),Vector3.zero);
		m_voxel.CreateCube(new Vector3(1f,0f,1f),new Vector3(255f,255f,0f),Vector3.zero);
		m_voxel.CreateCube(new Vector3(2f,0f,0.0f),new Vector3(255f,255f,0f),new Vector3(0f,45f,0f));

		m_voxel.UpdateMesh ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = m_voxel.GetBlock(0).pos;
		Vector3 ang = m_voxel.GetBlock(0).angle;
		Vector3 scale = m_voxel.GetBlock(0).scale;

		ang.x += 1f;
		ang.y += 1f;
		ang.z += 1f;
		pos.y = m_voxel.GetBlock(0).offset.y+Mathf.Sin(m_debugYFrameCount)*0.5f;

		scale.x = 1f+Mathf.Sin(m_debugYFrameCount)*0.5f;
		scale.y = 1f+Mathf.Sin(m_debugYFrameCount)*0.5f;
		scale.z = 1f+Mathf.Sin(m_debugYFrameCount)*0.5f;

		m_voxel.UpdateBlockPosition (0, pos);
		m_voxel.UpdateBlockRotation (0, ang);
		m_voxel.UpdateBlockScale (0, scale);
		m_debugYFrameCount += 0.1f;

		Vector3 angle = m_voxel.GetBlock(1).angle;
		angle.x += 1f;
		angle.y += 1f;
		angle.z += 1f;
		m_voxel.UpdateBlockRotation (1, angle);

		Vector3 angle2 = m_voxel.GetBlock(2).angle;
		angle2.x += 1.5f;
		angle2.y -= 1.5f;
		angle2.z -= 1.5f;
		m_voxel.UpdateBlockRotation (2, angle2);

		m_voxel.UpdateMesh ();

	}

}
