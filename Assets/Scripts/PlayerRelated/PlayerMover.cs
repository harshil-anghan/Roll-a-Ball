using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public float speed;
	public Text countscore;
	public Text Timer;
	public Text life;
	public Text gameover;
	private int count;
	private int limit;
	public int lifecount;
	Vector3 movement;
	Vector3 movement1;
	Vector3 newpos;
	public Rigidbody rb;
	float camRaya = 1000f;
	public Vector3 spawn;
	Animator anime;
	int planemask;
	bool isground;
	public Health healthscript;
	public GameObject deathparticle;
	public TurretShoot turretattack;
	//PlayerFollow cam;


	void Awake () {
		planemask = LayerMask.GetMask("Floor");
		healthscript = GetComponent<Health>();
		count = 0;
		limit = 5;
		lifecount = 3;
		rb = GetComponent<Rigidbody>();
		anime = GetComponent<Animator>();
		//cam = GetComponent<PlayerFollow>();
	}


	void Start () {
		spawn = transform.position;
		count_score();
		set_limit();
		set_life();
		gameover.text ="";
	}


	void FixedUpdate () {
		//Debug.Log(Input.mousePosition);
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		if(Input.GetKey(KeyCode.Space)&& isground == true)
		{
			rb.velocity= new Vector3(0f,15f,0f);
		}
		rb.AddForce(Vector3.down * 10f);

		if(Input.GetKey(KeyCode.W))
		{
			moveforward();
		}

		if(Input.GetKey(KeyCode.D))
		{
			moveright();
		}
		/*if(Input.GetMouseButton(2))
		{
			
		}*/
		if(Input.GetKey(KeyCode.S))
		{
			movebackward();
		}
		if(Input.GetKey(KeyCode.A))
		{
			moveleft();
		}
	//	move(h,v);
	//	newmove(h,v);
		turning();

	}

	/*void move(float h,float v)
	{
		movement.Set(h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition(transform.position + movement);

	}

	void newmove(float h,float v)
	{
		Vector3 movement = transform.forward * v * 40 * Time.deltaTime;
		rb.MovePosition(transform.position + movement);
	}
	*/
	void moveforward()
	{
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}
	void movebackward()
	{
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}
	void moveright()
	{
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}
	void moveleft()
	{
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}


	void turning()
	{
		Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if(Physics.Raycast(camray , out hit , camRaya , planemask))
		{
			Vector3 playerToMouse = hit.point - transform.position;

			//playerToMouse.y = 0f;

			//rb.MovePosition (playerToMouse) ;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

			rb.MoveRotation(newRotation);

		}

	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("pickup_green"))
		{
			rb.GetComponent<Renderer>().material.color = Color.green;
			col.gameObject.SetActive(false);
			count++;
			count_score();
			CancelInvoke("call_timer");
			limit=3;
		}
		if(col.gameObject.CompareTag("pickup_red"))
		{
			rb.GetComponent<Renderer>().material.color = Color.red;
			col.gameObject.SetActive(false);
			count++;
			count_score();
			CancelInvoke("call_timer");
			InvokeRepeating("call_timer",1,1);
			limit=5;
			Timer.text = "Timer : " + limit.ToString();
		}
		if(col.gameObject.CompareTag("speeder"))
		{
			col.gameObject.SetActive(false);
			speed = 40f;
		}
		if(col.gameObject.CompareTag("LaserGrid"))
		{
			healthscript.TakeDamage(0.3);
			if(healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();
				decrease_life();
				Instantiate(deathparticle,transform.position,Quaternion.identity);
				transform.position = spawn;
				healthscript.rebirth();
			}
			if(lifecount<=0)
			{
				youlose();
			}
		}
		if(col.gameObject.CompareTag("increasehealth"))
		{
			col.gameObject.SetActive(false);
			if(healthscript.healthSlider.value<=100)
			healthscript.healthSlider.value += 30;
		}
		if(col.CompareTag("EFireBall"))
			{
				healthscript.TakeDamage(0.1);
				if(healthscript.currentHealth <= 0)
				{
				//player.GetComponent<PlayerMover>().youlose();
					decrease_life();
					Instantiate(deathparticle,transform.position,Quaternion.identity);
					transform.position = spawn;
					healthscript.rebirth();
				}
				if(lifecount<=0)
				{
					youlose();
				}
			}

	}
	void OnCollisionStay()
	{
		isground = true;
	//	rb.GetComponent<Renderer>().material.color = Color.blue;
	}
	void OnCollisionExit()
	{
		isground = false;
	//	rb.GetComponent<Renderer>().material.color = Color.cyan;
	}
	/*void animating(float h , float v)
	{
		bool walking = v != 0f || h != 0f;
		anime.SetBool("IsWalking",walking);

	}*/

	void count_score()
	{
		countscore.text = "Score : " + count.ToString();
	}

	void set_limit()
	{
		Timer.text = "Timer : " + limit.ToString();
	}

	void call_timer()
	{
		if(limit!=0)
		{
		limit--;
		Timer.text = "Timer : " + limit.ToString();
		}
		if(limit==0)
		{
			youlose();
		}
	}

	public void youlose()
	{
		gameover.text = "Game Over !!";
		Time.timeScale = 0;
	}

	void set_life()
	{
		life.text = "Life : " + lifecount.ToString();
	}

	public void decrease_life()
	{
		lifecount--;
		life.text = "Life : " + lifecount.ToString();
	}
		
}
