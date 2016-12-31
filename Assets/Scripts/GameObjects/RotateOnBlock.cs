using UnityEngine;
using System.Collections;

public class RotateOnBlock : MonoBehaviour {

	public float x;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
			transform.Rotate(new Vector3(x,0,0) * Time.deltaTime);
	}
}
