using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyshoot : MonoBehaviour
{
	public int attackDamage = 30;
	public Transform target;
	LineRenderer line;
	GameObject player;
	public bool inrange;
	Health playerhealth;
	public GameObject deathparticle;
	public BPlayerMover bplayer;

	void Awake()
	{
		player = GameObject.Find("Player");
		playerhealth = player.GetComponent<Health>();
		bplayer = player.GetComponent<BPlayerMover>();
		line = gameObject.GetComponent<LineRenderer>();

	}
	void Start()
	{
		line.enabled = false;	
		//Screen.lockCursor = true;
	}

	void Update()
	{
		
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			inrange = true;
			//InvokeRepeating("Lasering",1,1f);
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");

		}
	}

	void OnTriggerExit()
	{
		inrange = false;	
		line.enabled = false;
	}
	IEnumerator FireLaser()
	{
		line.enabled = true;
		while (inrange)
		{
			Ray ray = new Ray(transform.position,transform.forward);
			RaycastHit hit;
			line.SetPosition(0, ray.origin);
			//line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,Time.time);
			//line.SetPosition(1, ray.GetPoint(100)); //---------->FOR  Letting Ray Through Walls and Objects !!!! Uncomment everything to hit it only within plane !
			if(Physics.Raycast(ray,out hit,1000))
			{
				//line.enabled = true;
				//Physics.queriesHitTriggers = true;
				line.SetPosition(1,target.position);

				//				if(hit.rigidbody)   //-----> If it hit any rigid body it will force to move
				//				{
				//					hit.rigidbody.AddForceAtPosition(transform.right * 5,hit.point);
				//				}
						//if (hit.rigidbody)//(hit.collider.CompareTag("Player"))          //-------------> For Disappearing the objects When hitted By Laser aka RayCast
				          //  {
				                    //hit.collider.gameObject.SetActive(false);
									//print("Got Hit");
									attack();
				            //}
				/*if(playerhealth.currentHealth <= 0)
				{
					playerscript.youlose();
				}*/
			}
			else
			{
				line.SetPosition(1,ray.GetPoint(1000));
			}
			yield return new WaitForSeconds(2);
		}
		line.enabled = false;
	}

	void attack()
	{
		if(playerhealth.currentHealth >= 0)
		{
			playerhealth.TakeDamage(attackDamage);
		}
		if(playerhealth.currentHealth <= 0)
		{
			//player.GetComponent<PlayerMover>().youlose();
			bplayer.decrease_life();
			Instantiate(deathparticle,player.transform.position,Quaternion.identity);
			player.transform.position = bplayer.spawn;
			playerhealth.rebirth();
		}
		if(bplayer.lifecount <= 0)
		{
			bplayer.youlose();
		}
	}
}
