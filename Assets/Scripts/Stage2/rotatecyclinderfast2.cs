using UnityEngine;
using System.Collections;

public class rotatecyclinderfast2 : MonoBehaviour {

	float timer;
	int converter;
	void Start () 
	{
		timer = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		timer = timer + Time.deltaTime;
		converter = (int)timer;
		if(converter%2 == 0)
		{
			flipper();	
		}
		//StopCoroutine("flipper");
		//StartCoroutine(flipper());

	}
	void flipper()
	{
		transform.Rotate(new Vector3(0,0,90f) * Time.deltaTime * 2);
	}
}
