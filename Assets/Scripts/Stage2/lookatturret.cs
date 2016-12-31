using UnityEngine;
using System.Collections;

public class lookatturret : MonoBehaviour {
	public Transform target;
	private int damp;
	// Use this for initialization
	void Start () {
		damp = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Quaternion rotate1 = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotate1,Time.deltaTime * damp);	
	}
}
