using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Reflection;

public class Health : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 10f;
	public Color flashColor = new Color(1f, 0f, 0f, 20f);
	BPlayerMover playermovement;
	bool isDead;
	bool damaged;
	public Vector3 rebirth_position;
	// Use this for initialization
	void Awake () {
		playermovement = GetComponent<BPlayerMover>();
		currentHealth = startingHealth;
	}
	void Start()
	{
		rebirth_position = GameObject.Find("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(damaged)
		{
			damageImage.color = flashColor;
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color,Color.clear,flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(double amount)
	{
		damaged = true;
		currentHealth = (int)(currentHealth - amount);
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death();
		}
	}

	void Death()
	{
		isDead = true;
		//playermovement.enabled = false;

	}

	public void rebirth()
	{
		if(playermovement.checkpoint_num == 1)
		{
			rebirth_position = GameObject.Find("CheckPoint").transform.position;
			GameObject.Find("Player").transform.position = rebirth_position;
		}
		else if(playermovement.checkpoint_num == 2)
		{
			rebirth_position = GameObject.Find("CheckPoint1").transform.position;
			GameObject.Find("Player").transform.position = rebirth_position;

		}
		else
		{
			GameObject.Find("Player").transform.position = rebirth_position;
		}
		currentHealth = startingHealth;
		healthSlider.value = currentHealth;
		isDead = false;
	}

}
