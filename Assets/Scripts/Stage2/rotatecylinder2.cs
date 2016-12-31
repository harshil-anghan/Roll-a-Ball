using UnityEngine;
using System.Collections;

public class rotatecylinder2 : MonoBehaviour {

	// Use this for initialization
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
		//Debug.Log(converter);
		if(converter%2 == 0)
		{
			flipper();	
		}
		//StopCoroutine("flipper");
		//StartCoroutine(flipper());

	}
	void flipper()
	{
		transform.Rotate(new Vector3(0,0,90f) * Time.deltaTime);
	}
}
