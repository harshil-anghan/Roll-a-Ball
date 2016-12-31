using UnityEngine;
using System.Collections;

public class wheel_mover_rotator : MonoBehaviour {
	private float tempx;
	public bool max;
	public int step;
	private float posx;
	public int maxamt;
	// Use this for initialization
	void Start () {
		posx = transform.position.x;
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(0,0,90f) * Time.deltaTime);	
		if(!max)
		{
			tempx = transform.position.x;
			tempx += step;
			Vector3 newpos = new Vector3(tempx,transform.position.y,transform.position.z);
			transform.position = Vector3.Lerp(transform.position,newpos,15f * Time.deltaTime);
		}
		else
		{

			tempx = transform.position.x;
			tempx -= step;
			Vector3 newpos = new Vector3(tempx,transform.position.y,transform.position.z);
			transform.position = Vector3.Lerp(transform.position,newpos,15f * Time.deltaTime);

		}
		if (transform.position.x >=posx+maxamt)
		{
			max = true;
		}
		else if(transform.position.x <=posx)
		{
			max = false;
		}
	}
}
