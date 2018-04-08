using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamaJump : MonoBehaviour
{
	public Rigidbody2D rb;
	public float force;
	private SpriteRenderer spriteRenderer;
	public Sprite frogWithBamboo;
	public int VelocityLR;
	public Sprite frog;
	private Collider2D water;
	private Collider2D hama;
	public GameObject waterObj;
	private bool timer_start = false;
	private float start_time;
	private float interval = 10f;
	//降落伞
	private bool valid_parachute;
	private float start_time_parachute;
	private float duration_parachute;

	//鳄鱼
	public Text ThreeText;
	private bool flag = false;
	private float timeLeft = 2f;
	public int count = 0;
	public GameObject myButton;
    public Button btn;
	public GameObject tag;

	public Sprite Drunkeyu;
	public GameObject leonard;

	public Sprite sally,cony,brown,leo,mainc;
	public Sprite fly_sally,fly_cony,fly_brown,fly_leo;
	public static string cha_name;

    //fire
    public float timer;

	//fire
	public float timer_ani;  
	public float time_ani; 
	public GameObject fire_dragon,fire_dragon1,fire_dragon2,fire_dragon3;
	public bool startFire = false;

	[Range(1f, 3f)]
	public float GrassForce;

	void Start()
	{
        timer = 0;

		timer_ani = 0;  
		time_ani = 3.0f; 
		fire_dragon=GameObject.Find("fire_dragon");
		fire_dragon1=GameObject.Find("fire_dragon1");
		fire_dragon2=GameObject.Find("fire_dragon2");
		fire_dragon3=GameObject.Find("fire_dragon3");
		
		leonard = GameObject.Find ("frog");
		cha_name=PlayerPrefs.GetString ("character","defalut");
		if (cha_name == "brownb") {
			Debug.Log ("brownb");
			mainc = brown;
			leonard.GetComponent<SpriteRenderer> ().sprite = brown;
		}  else if (cha_name == "sally") {
			mainc = sally;
			leonard.GetComponent<SpriteRenderer> ().sprite = sally;
		}  else if (cha_name == "cony") {
			mainc = cony;
			leonard.GetComponent<SpriteRenderer> ().sprite = cony;
		}  else {
			mainc = leo;
			leonard.GetComponent<SpriteRenderer> ().sprite = leo;
		}
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		spriteRenderer = GetComponent<SpriteRenderer>();
		water = GameObject.Find("WaterCollider").GetComponent<Collider2D>();
		hama = GameObject.Find("frog").GetComponent<Collider2D>();
		//降落伞，降落伞图片待换
		spriteRenderer.sprite = mainc;
		valid_parachute = true;
		start_time_parachute = Time.time;
		duration_parachute = 0f;
		//鳄鱼

		//myButton = GameObject.Find("Button");
		//Button btn = myButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
		myButton.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
        //bomb
        timer += Time.deltaTime;
        //8s
        if (timer >= 8)
        {
            timer = 0;
            GameObject bombPrefab = Resources.Load<GameObject>("Prefabs/bomb");

            Vector2 point1 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Vector2 point2 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Vector2 point3 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Vector2 point4 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Vector2 point5 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Vector2 point6 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Vector2 point7 = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            GameObject bomb1 = GameObject.Instantiate(bombPrefab, point1, bombPrefab.transform.rotation) as GameObject;
            GameObject bomb2 = GameObject.Instantiate(bombPrefab, point2, bombPrefab.transform.rotation) as GameObject;
            GameObject bomb3 = GameObject.Instantiate(bombPrefab, point3, bombPrefab.transform.rotation) as GameObject;
            GameObject bomb4 = GameObject.Instantiate(bombPrefab, point4, bombPrefab.transform.rotation) as GameObject;
            GameObject bomb5 = GameObject.Instantiate(bombPrefab, point5, bombPrefab.transform.rotation) as GameObject;
            GameObject bomb6 = GameObject.Instantiate(bombPrefab, point6, bombPrefab.transform.rotation) as GameObject;
            GameObject bomb7 = GameObject.Instantiate(bombPrefab, point7, bombPrefab.transform.rotation) as GameObject;

        }
        if (timer_ani>0)  
			timer_ani-= Time.deltaTime;  
		if (timer_ani<0)  
			timer_ani=0;  
		if(timer_ani == 0)  
		{  
			fire();  
			timer_ani =time_ani;  
		}
		if (!GameControl.instance.gameOver)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				rb.AddForce(transform.up * force);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				rb.AddForce(transform.right * -force);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				rb.AddForce(transform.right * force);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				rb.AddForce(transform.up * -force);
			}
		}

		//降落伞结束
		if (valid_parachute && Time.time > start_time_parachute + duration_parachute)
		{
			valid_parachute = false;
			spriteRenderer.sprite = mainc;
			waterObj.SetActive(true);
		}

		//竹蜻蜓结束
		if (timer_start == true)
		{
			if (Time.time > start_time + interval)
			{
				timer_start = false;
				spriteRenderer.sprite = mainc;
				waterObj.SetActive(true);
				Physics2D.IgnoreLayerCollision (8, 9, false);
                FindObjectOfType<AudioManager>().Stop("Helicopter");
			}
		}

		//鳄鱼
		if (flag)
		{
			myButton.SetActive(true);
			timeLeft -= Time.deltaTime;
			ThreeText.text = "time left: " + (int)timeLeft;
			Debug.Log("time Left:" + timeLeft);
			if (count >= 6)
			{
				Debug.Log("eyu disappear");
				ThreeText.text = "";
				//ThreeText.text = "";
				flag = false;
				myButton.SetActive(false);
				tag.SetActive(false);
                count = 0;
				timeLeft = 1f;
                FindObjectOfType<AudioManager>().Stop("Crocodile");
            }
			if (timeLeft < 0)
			{
				ThreeText.text = "continue push again!";

				Debug.Log("continue push again");
				// count = 0;

			}

		}

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{  
		if (collision.tag == "Fountain")
		{
			GameControl.instance.success();

		}
		if (collision.tag == "Water" && transform.parent==null)
		{
			GameControl.instance.frogDied();
			frogStop();
			GameObject move = GameObject.FindGameObjectWithTag ("Move");
            move.SetActive(false);

		}
		
		if (collision.tag == "BambooCopter")
		{   collision.gameObject.SetActive (false);
			KnapsackManager.Instance.StoreItem (0);



		}
		if (valid_parachute)
		{
			//collision.gameObject.SetActive(false);
			waterObj.SetActive(false);
		}
		if (collision.tag == "crocodile")
		{
			//play the crocodile sound effect
			FindObjectOfType<AudioManager> ().Play ("Crocodile");
			collision.gameObject.GetComponent<SpriteRenderer>().sprite = Drunkeyu;
			Debug.Log("pengdao eyu");
			flag = true;
			tag = collision.gameObject;
		}
		if (collision.tag == "medicine") {
			collision.gameObject.SetActive (false);
			KnapsackManager.Instance.StoreItem (1);
		}
		//fire
		if (collision.tag == "fire_dragon"||collision.tag == "fire_dragon1"||collision.tag == "fire_dragon2"||collision.tag == "fire_dragon3") {
			Debug.Log ("reach fire!");
			GameControl.instance.frogDied();
			frogStop();
			GameObject move = GameObject.FindGameObjectWithTag("Move");
			move.SetActive(false);
		}

        //bomb
        if (collision.tag == "Bomb")
        {
            Debug.Log("touch bomb");
            Vector3 vector = transform.position - collision.gameObject.transform.position;
            rb.AddForce((300 / vector.magnitude) * vector);
            GameControl.instance.frogDied();
            frogStop();
            GameObject move = GameObject.FindGameObjectWithTag("Move");
            move.SetActive(false);
        }

    }

	private void OnTriggerStay2D(Collider2D collision)
	{   if (collision.tag == "Fountain")
		{
			frogStop();
		}
		if (collision.tag == "Water" && transform.parent==null)
		{
			GameControl.instance.frogDied();
			frogStop();
            GameObject move = GameObject.FindGameObjectWithTag("Move");
            move.SetActive(false);
        }
		if (collision.tag == "left")
		{
			Debug.Log("left");
			//rb.velocity = new Vector2(0, 0);
			rb.AddForce(transform.right * -VelocityLR);
		}
		if (collision.tag == "right")
		{
			//rb.AddForce (transform.right * VelocityLR);
			rb.AddForce(transform.right * VelocityLR);
			Debug.Log("right");
		}
		if (collision.tag == "crocodile")
		{
			frogStop();
            Debug.Log("frog stop");
			// CountDown.instance.StartCount(collision.gameObject);

			// animation_countdown = GameObject.Find("crocodile-1").GetComponent<Animation>();
			//animation_countdown.Play();

		}
		if (collision.tag == "Grass")
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				rb.AddForce(transform.up * GrassForce);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				rb.AddForce(transform.right * -GrassForce);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				rb.AddForce(transform.right * GrassForce);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				rb.AddForce(transform.up * -GrassForce);
			}
		}


	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Circle")
		{
			GameControl.instance.frogDied();
			frogStop();
		}


	}
	public void frogStop()
	{
		rb.velocity = new Vector2(0, 0);
	}
	public void TaskOnClick()
	{
		count++;

		Debug.Log(count);
	}
	public void fly(){
		//play the helicopter sound effect
		FindObjectOfType<AudioManager> ().Play ("Helicopter");
		if (cha_name == "brownb") {
			Debug.Log ("brownb_fly!!");
			leonard.GetComponent<SpriteRenderer> ().sprite = fly_brown;
		} else if (cha_name == "sally") {
			Debug.Log ("sallly fly");
			leonard.GetComponent<SpriteRenderer> ().sprite = fly_sally;
		} else if (cha_name == "cony") {
			leonard.GetComponent<SpriteRenderer> ().sprite = fly_cony;
		} else {
			Debug.Log ("leo fly");
			leonard.GetComponent<SpriteRenderer> ().sprite = fly_leo;
		}
		//change collision
		waterObj.SetActive(false);
		Physics2D.IgnoreLayerCollision (8, 9);
		timer_start = true;
		start_time = Time.time;
	}

	public void medicine(){
		print ("medicine");
	}

	public void fire(){
		if (startFire == false) {
			fire_dragon.GetComponent<BoxCollider2D> ().enabled = false;
			fire_dragon1.GetComponent<BoxCollider2D> ().enabled = false;
			fire_dragon2.GetComponent<BoxCollider2D> ().enabled = false;
			fire_dragon3.GetComponent<BoxCollider2D> ().enabled = false;
			startFire = true;
		} else {
			fire_dragon.GetComponent<BoxCollider2D> ().enabled = true;
			fire_dragon1.GetComponent<BoxCollider2D> ().enabled = true;
			fire_dragon2.GetComponent<BoxCollider2D> ().enabled = true;
			fire_dragon3.GetComponent<BoxCollider2D> ().enabled = true;
			startFire = false;
		}

	}


}
