using UnityEngine;
using System.Collections;

public class OuterLift : MonoBehaviour {
	private float ypos;
	private float xpos;
	public bool vert;
	public int maxamt;
	public float step;
	float tempy;
	bool max;
	// Use this for initialization
	void Start () {
		xpos = transform.position.x;
		ypos = transform.position.y;
	}

	// Update is called once per frame
	void Update () 
	{
		if(vert)
		{

			if(!max)
			{
				tempy = transform.position.y;
				tempy += step;
				Vector3 newpos = new Vector3(transform.position.x,tempy,transform.position.z);
				transform.position = Vector3.Lerp(transform.position,newpos,15f * Time.deltaTime);
			}
			else
			{

				tempy = transform.position.y;
				tempy -= step;
				Vector3 newpos = new Vector3(transform.position.x,tempy,transform.position.z);
				transform.position = Vector3.Lerp(transform.position,newpos,15f * Time.deltaTime);

			}
			if(vert)
			{
				if (transform.position.y >=ypos+maxamt)
				{
					max = true;
				}
				else if(transform.position.y <=ypos)
				{
					max = false;
				}
			}
		}
	}
}