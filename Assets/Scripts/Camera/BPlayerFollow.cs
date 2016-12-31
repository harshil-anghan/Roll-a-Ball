using UnityEngine;
using System.Collections;

public class BPlayerFollow : MonoBehaviour {

	public GameObject lookAt;
	private Vector3 offset;
	private float distance = 10.0f;
	private float yoffset = 5.0f;

	void Awake()
	{
		
	}
	private void Start()
	{
		offset = new Vector3(0,yoffset,-1f * distance);
		lookAt = GameObject.Find("Player");
	}

	private void Update()
	{
		transform.position = lookAt.transform.position + offset;
		if(Input.GetKeyDown(KeyCode.LeftArrow)/* || SwipeManager.Instance.isSwiping(SwipeDirection.Left)*/)
		{
				Slider(true);
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow)/* || SwipeManager.Instance.isSwiping(SwipeDirection.Right)*/)
		{
			Slider(false);
		}

		transform.LookAt(lookAt.transform);
	}
	public void onclick_left()
	{
		Slider(true);
		//transform.LookAt(lookAt.transform);
	}

	public void onclick_right()
	{
		Slider(false);
	}
	public void Slider(bool left)
	{
		if(left)
		{
			offset = Quaternion.Euler(0,90,0) * offset;
		}
		else
		{
			offset = Quaternion.Euler(0,-90,0) * offset;
		}
	}
}
