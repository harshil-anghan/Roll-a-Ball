using UnityEngine;
using System.Collections;

public class FireBallShooter_C : MonoBehaviour {
	public GameObject FireBall;
	public float fireball_speed;
	public float distance = 50.0f;
	int planemask;
	// Use this for initialization
	void Awake () 
	{
		planemask = LayerMask.GetMask("Floor");
	}
	
	// Update is called once per frame
	void Update () 
	{
		turning();
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject bullet = Instantiate(FireBall,GameObject.Find("SpawnPoint").transform.position,Quaternion.identity)as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * fireball_speed);
		}

	}
	void turning()
	{
		Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if(Physics.Raycast(camray , out hit , 100000000 , planemask))
		{
			Vector3 playerToMouse = hit.point - transform.position;

			//playerToMouse.y = 0f;

			//rb.MovePosition (playerToMouse) ;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

			transform.rotation = newRotation;

		}
	}
}