using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Boundary
{
	public float xMin,xMax;	
}


public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate; 

	private Rigidbody rb;
	private float nextFire;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{  // Fire Control
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}		
	}	

	void FixedUpdate () 
	{   // Player Movement Control
		float moveH = Input.GetAxisRaw ("Horizontal");
		//float moveV = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3 (moveH, 0.0f, 0.0f);

		rb.velocity = movement * speed;
		rb.position = new Vector3 ( Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),rb.position.y,rb.position.z);

	}

	void OnTriggerEnter(Collider other)
	{   
		if (other.tag == "Ball") 
		{
			GameOver ();
		} 
	}

	 
	void GameOver()
	{
		Time.timeScale = 0;
		SceneManager.LoadScene ("GameOver");
	}
}
