using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BPlayerMover : MonoBehaviour
{

	public Text countscore;
	public Text wintext;
	public Text Timer;
	public Text life;
	public int checkpoint_num;
	public Text gameover;
	private int count;
	private int remaining_count;
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
	int planemask1;
	bool isground;
	public Health healthscript;
	public GameObject deathparticle;
	public TurretShoot turretattack;
	public JoyStick moveJoyStick;
	public int dbljump = 2;
	int winning_point=0;
	//public Model_Selector characterindex;
	//PlayerFollow cam;

	public float movespeed = 20.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;

	public Transform camTransform;

	public GameObject MainCamera;
	public GameObject SecondCam;

	void Awake()
	{
		planemask = LayerMask.GetMask("Floor");
		planemask1 = LayerMask.GetMask("Default");
		healthscript = GetComponent<Health>();
		count = 0;
		remaining_count = 30;
		limit = 5;
		lifecount = 3;
		rb = GetComponent<Rigidbody>();
		anime = GetComponent<Animator>();
	//	characterindex = GetComponent<Model_Selector>();
		//cam = GetComponent<PlayerFollow>();
	}


	void Start()
	{
		spawn = transform.position;
		rb.maxAngularVelocity = terminalRotationSpeed;
		rb.drag = drag;
		camTransform = Camera.main.transform;
		count_score();
		set_limit();
		set_life();
		gameover.text = "";
		wintext.text = "";
		//print(characterindex.);
	}


	void FixedUpdate()
	{
		//Debug.Log(Input.mousePosition);

		Vector3 dir = Vector3.zero;

		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");

		if(moveJoyStick.InputDirection != Vector3.zero)
		{
			dir = moveJoyStick.InputDirection;
		}
		//----------------------------------------------------------------------------------------------------------------------
		if(isground==true && dbljump!=1 || dbljump!=1)
		{
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)/*SwipeManager.Instance.isSwiping(SwipeDirection.Up)*/)
			{

				rb.velocity = new Vector3(0f, 15f, 0f);
				//jumped = dbljump - jumped;
				dbljump--;
				//Debug.Log(jumped);
			}
			rb.AddForce(Vector3.down * 25f);
		}
		//-----------------------------------------------------------------------------------------------------------------------
		//Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);

		//RaycastHit hit;

		//if(Physics.Raycast(camray , out hit , 100000000 , planemask) || Physics.Raycast(camray , out hit , 100000000 , planemask1))
		//{
		/*if(Input.GetKeyDown(KeyCode.Space))
		{

			rb.velocity = new Vector3(0f, 18f, 0f);
			//jumped = dbljump - jumped;
			//dbljump--;
			//Debug.Log(jumped);
		}
		rb.AddForce(Vector3.down * 20f);*/

		Vector3 rotateDir = camTransform.TransformDirection(dir);
		rotateDir = new Vector3(rotateDir.x,0,rotateDir.z);
		rotateDir = rotateDir.normalized * dir.magnitude;

		rb.AddForce(rotateDir * movespeed);

	}

	public void jump()
	{
		if(isground==true && dbljump!=1 || dbljump!=1)
		{
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)/*SwipeManager.Instance.isSwiping(SwipeDirection.Up)*/)
			{
				
				rb.velocity = new Vector3(0f, 15f, 0f);
				//jumped = dbljump - jumped;
				dbljump--;
				//Debug.Log(jumped);
			}
			rb.AddForce(Vector3.down * 25f);
		}
	}

	void move(float h,float v)
	{
		movement.Set(h,0f,v);
		movement = movement.normalized * movespeed * Time.deltaTime;
		rb.MovePosition(transform.position + movement);

	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("pickup_green"))
		{
			//rb.GetComponent<Renderer>().material.color = Color.green;
			col.gameObject.SetActive(false);
			count++;
			count_score();
			CancelInvoke("call_timer");
			limit = 3;
		}
		if (col.gameObject.CompareTag("pickup_red"))
		{
			//rb.GetComponent<Renderer>().material.color = Color.red;
			col.gameObject.SetActive(false);
			count++;
			count_score();
			CancelInvoke("call_timer");
			InvokeRepeating("call_timer", 1, 1);
			limit = 7;
			Timer.text = "Timer : " + limit.ToString();
		}
		if (col.gameObject.CompareTag("speeder"))
		{
			col.gameObject.SetActive(false);
			movespeed = 80f;
		}
		if (col.gameObject.CompareTag("LaserGrid"))
		{
			healthscript.TakeDamage(5);
			if (healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();
				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
			}
			if (lifecount <= 0)
			{
				youlose();
			}
		}
		if (col.gameObject.CompareTag("YellowGrid"))
		{
			healthscript.TakeDamage(5);
			if (healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();
				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
			}
			if (lifecount <= 0)
			{
				youlose();
			}
		}
		if (col.gameObject.CompareTag("OrangeGrid"))
		{
			healthscript.TakeDamage(5);
			if (healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();
				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
			}
			if (lifecount <= 0)
			{
				youlose();
			}
		}
		if (col.gameObject.CompareTag("increasehealth"))
		{
			col.gameObject.SetActive(false);
			if (healthscript.healthSlider.value <= 100)
				healthscript.healthSlider.value += 30;
		}
		if (col.CompareTag("EFireBall"))
		{
			healthscript.TakeDamage(1);
			if (healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();
				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
			}
			if (lifecount <= 0)
			{
				youlose();
			}
		}
		if (col.CompareTag("Spikes"))
		{
			healthscript.TakeDamage(10);
			rb.velocity = new Vector3(0f, 10f, 0f);
			if (healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();

				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
			}
			if (lifecount <= 0)
			{
				youlose();
			}
		}
		if (col.CompareTag("wheel_ball"))
		{
			rb.velocity = new Vector3(0f,0f,-20f);
			healthscript.TakeDamage(10);
			//rb.velocity = new Vector3(0f, 10f, 0f);
			if (healthscript.currentHealth <= 0)
			{
				//player.GetComponent<PlayerMover>().youlose();

				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
			}
			if (lifecount <= 0)
			{
				youlose();
			}
		}
		if (col.CompareTag("Spring"))
		{
			rb.velocity = new Vector3(0f, 60f, 0f);
		}
		if (col.CompareTag("deathground"))
			{
				decrease_life();
				healthscript.rebirth();
				if (lifecount <= 0)
				{
					youlose();
				}
			}
		if (col.CompareTag("pushing_cylinder"))
		{
			rb.velocity = new Vector3(0f,0f,-20f);
		}

		if(col.CompareTag("checkpoint"))
		{
			checkpoint_num = 1;
			GameObject.Find("CheckPoint").GetComponent<Renderer>().material.color = Color.green;
			//rb.GetComponent<Renderer>().material.color = Color.green;
		}
		if(col.CompareTag("checkpoint1"))
		{
			checkpoint_num = 2;
			GameObject.Find("CheckPoint1").GetComponent<Renderer>().material.color = Color.green;
			//rb.GetComponent<Renderer>().material.color = Color.green;
		}
		if(col.CompareTag("Final"))
		{
			
			GameObject.Find("Final").GetComponent<Renderer>().material.color = Color.yellow;
			winning_point++;
			if(count>=remaining_count && winning_point>=1)
			{
				wintext.text = "You Win!!";
				Time.timeScale = 0;
			}

			//rb.GetComponent<Renderer>().material.color = Color.green;
		}

	}
	void OnCollisionStay()
	{
		isground = true;
		dbljump = 2;
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
		countscore.text = "Score : " + count.ToString() + "/" + remaining_count.ToString();
	}
	void set_limit()
	{
		Timer.text = "Timer : " + limit.ToString();
	}

	void call_timer()
	{
		if (limit != 0)
		{
			limit--;
			Timer.text = "Timer : " + limit.ToString();
		}
		if(limit == 0)
		{
			if(lifecount!=0)
			{
				decrease_life();
				Instantiate(deathparticle, transform.position, Quaternion.identity);
				//transform.position = spawn;
				healthscript.rebirth();
				limit = 7;
				Timer.text = "Timer : " + limit.ToString();
				CancelInvoke("call_timer");

			}
			if(lifecount<=0)
			{
				youlose();
			}
		}

	}

	public void youlose()
	{
		Time.timeScale = 0;
		gameover.text = "Game Over !!";
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
