using UnityEngine;
using System.Collections;

public class camera_joy : MonoBehaviour {

	// Use this for initialization
	//public GameObject woodball;
	//public Transform wood;
	public Transform atom;
	//public Transform metal;

	public JoyStick cameraJoystick;

	float distance = 12.0f;
	float currentX = 0.0f;
	float currentY = 30.0f;
	float sensitivityX = 0.8f;
	float sensitivityY = 0.8f;

	void Start () {
		//player = woodball.transform.Find("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		currentX += cameraJoystick.InputDirection.x * sensitivityX;
		currentY += cameraJoystick.InputDirection.z * sensitivityY;
	}

	void LateUpdate()
	{
		Vector3 dir = new Vector3(0,0,-distance);
		Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
		/*if(Model_Selector.SelectionIndex == 0)
		{
			transform.position = wood.position + rotation * dir;
			transform.LookAt (wood);
		}
		else if(Model_Selector.SelectionIndex == 1)
		{
			transform.position = atom.position + rotation * dir;
			transform.LookAt (atom);
		}
		else if(Model_Selector.SelectionIndex == 2)
		{
			transform.position = metal.position + rotation * dir;
			transform.LookAt (metal);
		}

	*/
		transform.position = atom.position + rotation * dir;
		transform.LookAt (atom);

	}
}
