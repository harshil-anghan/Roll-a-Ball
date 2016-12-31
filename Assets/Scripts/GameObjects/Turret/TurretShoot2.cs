using UnityEngine;
using System.Collections;

public class TurretShoot2 : MonoBehaviour {
	public GameObject FireBall;
	public float fireball_speed;
	public bool inrange;
	GameObject player;
	Health playerhealth;
	public GameObject deathparticle;
	// Use this for initialization

	void Start () {
		player = GameObject.Find("Player");
		playerhealth = player.GetComponent<Health>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			inrange = true;
			InvokeRepeating("shoot",1f,0.5f);
		}
	}
	void OnTriggerExit()
	{
		CancelInvoke("shoot");
		inrange = false;	
	}
	void shoot()
	{
		GameObject bullet = Instantiate(FireBall,GameObject.Find("TurretShootingSpawn2").transform.position,Quaternion.identity)as GameObject;
		bullet.GetComponent<Rigidbody>().AddForce(GameObject.Find("TurretShootingSpawn2").transform.forward * fireball_speed);
	}


	/*public void attack()
	{
		if(playerhealth.currentHealth >= 0)
		{
			playerhealth.TakeDamage(40);
		}
		if(playerhealth.currentHealth <= 0)
		{
			//player.GetComponent<PlayerMover>().youlose();
			player.GetComponent<PlayerMover>().decrease_life();
			Instantiate(deathparticle,player.transform.position,Quaternion.identity);
			player.transform.position = player.GetComponent<PlayerMover>().spawn;
			playerhealth.rebirth();
		}
		if(player.GetComponent<PlayerMover>().lifecount <= 0)
		{
			player.GetComponent<PlayerMover>().youlose();
		}
	}*/

}
