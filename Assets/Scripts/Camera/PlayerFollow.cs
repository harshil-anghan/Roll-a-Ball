using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	public Transform target;
	private float x = 0.0f;
	private float y = 0.0f;
	private float distance = 5.0f;
	public float smoothing = 5f;
	Vector3 offset;


	void Start () {
		offset = transform.position - target.position;
		Vector3 angels = transform.eulerAngles;
		x = angels.y;
		y = angels.x;
	}


	void FixedUpdate () 
	{
		Vector3 targetcampos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position,targetcampos,smoothing * Time.deltaTime);
		if(Input.GetMouseButton(1))
		{
			x += Input.GetAxis("Mouse X") * smoothing;
			y -= Input.GetAxis("Mouse Y") * smoothing;
			Quaternion rotation = Quaternion.Euler(y,x,0);
			transform.rotation = rotation;
		}
	}
}