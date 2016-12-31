using UnityEngine;
using System.Collections;

public class spike : MonoBehaviour {
	private float tempz;
	public bool max;
	public int step;
	private float posz;
	public int maxamt;
	// Use this for initialization
	void Start () {
		posz = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(0,0,90f) * Time.deltaTime);	
		if(!max)
		{
			tempz = transform.position.z;
			tempz += step;
			Vector3 newpos = new Vector3(transform.position.x,transform.position.y,tempz);
			transform.position = Vector3.Lerp(transform.position,newpos,15f * Time.deltaTime);
		}
		else
		{

			tempz = transform.position.z;
			tempz -= step;
			Vector3 newpos = new Vector3(transform.position.x,transform.position.y,tempz);
			transform.position = Vector3.Lerp(transform.position,newpos,15f * Time.deltaTime);

		}
		if (transform.position.z >=posz+maxamt)
		{
			max = true;
		}
		else if(transform.position.z <=posz)
		{
			max = false;
		}
	}
}
