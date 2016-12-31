using UnityEngine;
using System.Collections;

public class enemyhealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	bool isDead;
	bool damaged;

	void Awake () 
	{
			currentHealth = startingHealth;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void TakeDamage(int amount)
	{
		damaged = true;
		currentHealth -= amount;

		if(currentHealth <= 0 && !isDead)
		{
			Death();
		}
	}
	void Death()
	{
		Destroy(gameObject);
		Destroy(GameObject.Find("enemy"));
		Destroy(GameObject.Find("eLazer"));
		isDead = true;
		//playermovement.enabled = false;
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("FireBall"))
		{
			print("got hit");
			/*enemyhealth enemy_health = GetComponent<enemyhealth>();
			if(enemy_health.currentHealth >= 0)
			{
				print("health decreased");
				enemy_health.TakeDamage(20);
			}*/
			if(currentHealth >= 0)
			{
				print("health decreased");
				TakeDamage(20);
			}
		}
	}
}
