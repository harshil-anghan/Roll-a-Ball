using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	LineRenderer line;
	void Start()
	{
		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = false;
		//Screen.lockCursor = true;
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		}
	}
	IEnumerator FireLaser()
	{
		line.enabled = true;
		while (Input.GetButton("Fire1"))
		{
			Ray ray = new Ray(transform.position,transform.forward);
			RaycastHit hit;
			line.SetPosition(0, ray.origin);
			//line.SetPosition(1, ray.GetPoint(100)); //---------->FOR  Letting Ray Through Walls and Objects !!!! Uncomment everything to hit it only within plane !
						if(Physics.Raycast(ray,out hit,1000))
						{
							line.SetPosition(1,hit.point);
				if(hit.collider.CompareTag("enemy"))
				{
					Physics.queriesHitTriggers = false;
				}
				else
				{
					Physics.queriesHitTriggers = true;
				}
			//				if(hit.rigidbody)   //-----> If it hit any rigid body it will force to move
			//				{
			//					hit.rigidbody.AddForceAtPosition(transform.right * 5,hit.point);
			//				}
			//            if (hit.collider.CompareTag("pick"))          //-------------> For Disappearing the objects When hitted By Laser aka RayCast
			//            {
			//                    hit.collider.gameObject.SetActive(false);
			//            }
						}
						else
						{
			                  line.SetPosition(1,ray.GetPoint(1000));
			          }


			yield return null;
		}
		line.enabled = false;
	}
}
