using UnityEngine;
using System.Collections;

public class PlaneTest : MonoBehaviour {
	private Plane plane;
	private int PLANE_NUM = 8000;

	// Use this for initialization
	void Start () {
		plane = gameObject.GetComponent<Plane> ();

		for(int i = 0; i<PLANE_NUM; i++) {
			Vector3 pos = new Vector3(Random.Range(-25f,25f), Random.Range(-25f,25f), Random.Range(-25f,25f));
			Vector3 rot = new Vector3(Random.Range(0f,360f), Random.Range(0f,360f), Random.Range(0f,360f));
			plane.CreatePlane(pos,new Vector3(255f,255f,255f),rot);
		}

		plane.UpdateMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < plane.planes.Count; i++) {
			Vector3 angle = plane.GetPlane (i).angle;
			angle.x += 1f;
			angle.y += 1f;
			angle.z += 1f;
			plane.UpdatePlaneRotation (i, angle);
		}

		plane.UpdateMesh ();
	}
}
