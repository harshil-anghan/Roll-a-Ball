#pragma strict

var buleetprefab : Transform;

function Start () {

}

function Update () {
	
	if(Input.GetButtonDown("Fire1"))
	{
		var bullet = Instantiate(buleetprefab,GameObject.Find("SpawnPoint").transform.position,Quaternion.identity);
		bullet.GetComponent.<Rigidbody>().AddForce(transform.forward * 2000);
	}

}