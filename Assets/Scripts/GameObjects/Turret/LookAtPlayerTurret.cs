using UnityEngine;
using System.Collections;

public class LookAtPlayerTurret : MonoBehaviour {
	public Transform woodball;
	public Transform metalball;
	public Transform atomball;
	public float damp = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(player);
		if(Model_Selector.SelectionIndex == 0)
		{
			woodball_method();
		}
		if(Model_Selector.SelectionIndex == 2)
		{
			metalball_method();
		}
		if(Model_Selector.SelectionIndex == 1)
		{
			atomball_method();
		}

	}

	void woodball_method()
	{
		Quaternion rotate1 = Quaternion.LookRotation(woodball.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotate1,Time.deltaTime * damp);
	}
	void atomball_method()
	{
		Quaternion rotate1 = Quaternion.LookRotation(atomball.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotate1,Time.deltaTime * damp);
	}
	void metalball_method()
	{
		Quaternion rotate1 = Quaternion.LookRotation(metalball.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotate1,Time.deltaTime * damp);
	}
}
