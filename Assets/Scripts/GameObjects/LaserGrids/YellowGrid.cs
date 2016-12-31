using UnityEngine;
using System.Collections;

public class YellowGrid : MonoBehaviour {

	GameObject gam;
	MeshRenderer m;
	BoxCollider bm;
	// Use this for initialization
	void Start () {
		gam = GameObject.FindGameObjectWithTag("YellowGrid");
		//gam = GameObject.FindGameObjectWithTag("LaserGrid");
		m = gam.GetComponent<MeshRenderer>();
		bm = GetComponent<BoxCollider>();
		laseron();
	}

	// Update is called once per frame
	void Update () {

		//gam = GetComponent<MeshRenderer>();

		InvokeRepeating("laseron",2,2);
		InvokeRepeating("laseroff",1.5f,2.5f);

	}

	void laseron()
	{
		m.enabled = true;
		bm.enabled = true;
	}
	void laseroff()
	{
		m.enabled = false;
		bm.enabled = false;
	}

}
