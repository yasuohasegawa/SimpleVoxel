using UnityEngine;
using System.Collections;

public class TerrainSample : MonoBehaviour {
	private SimpleVoxel.Voxel m_voxel;
	private static int COL = 50;
	private static int ROW = 50;

	// Use this for initialization
	void Start () {
		m_voxel = gameObject.GetComponent<SimpleVoxel.Voxel> ();

		float yoff = 0f;
		for (int y = 0; y<TerrainSample.ROW; y++) {
			float xoff = 0.0f;
			for (int x = 0; x<TerrainSample.COL; x++) {
				float dx = (float)x-((float)TerrainSample.COL*0.5f);
				float dz = (float)y-((float)TerrainSample.ROW*0.5f);
				float dy = map(Mathf.PerlinNoise(xoff,yoff),0f,0.6f,-1f,1f);

				if (dy < 0.3f) {
					m_voxel.CreateCube (new Vector3 (dx, dy, dz), new Vector3 (255f, 0f, 255f), Vector3.zero, new Vector2 (0, 1));
				} else {
					m_voxel.CreateCube(new Vector3(dx,dy,dz),new Vector3(255f,0f,255f),Vector3.zero,new Vector2(0,0),new Vector2(1,1));
				}

				xoff += 0.2f;
			}
			yoff += 0.2f;
		}
			
		m_voxel.UpdateMesh ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private float map(float v, float sx, float sn, float dx, float dn){
		return (v - sn) * (dx - dn) / (sx - sn) + dn;
	}
}
