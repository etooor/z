using UnityEngine;
using System.Collections;

public class Popping : MonoBehaviour {
 
	//public Vector3 posi, size, force;

	public GameObject ball;
	public float xSpeed = 5;

	//Transform trans;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		rb.AddForce( new Vector3(xSpeed,0,0),ForceMode.VelocityChange);
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Shot") 
		{    //Destroy shot object and pop bubble/ball
			Destroy (other.gameObject);
			Pop ();
		} 
	}

	void OnCollisionEnter(Collision col) 
	{   //Add x Force every bounce 
		switch (col.gameObject.name) { 
		case "Floor":		rb.AddForce (new Vector3 (xSpeed, 0, 0), ForceMode.VelocityChange);
			break;
		case "RWall":		xSpeed *= -1;
			break;
		case "LWall":       xSpeed *= -1;
			break;
		default:
			break;
		}		
	}

	void Pop ()
	{   //Creates two childs
		if (transform.localScale.x > 2) 
		{
			NewBall (0); //  <  O
			NewBall (1); //     O  >
		}
		Destroy (this.gameObject);
	}


	void NewBall (int childNum)
	{
		Vector3 iniPos = transform.position;
		float iniXSpeed = Mathf.Abs (xSpeed);
	
		if (childNum == 0) {
			iniPos.x -= 2; 
			iniXSpeed *=-1;
		} else {
			iniPos.x += 2;
		}	
		GameObject bChild = Instantiate (ball, iniPos, Quaternion.identity) as GameObject;
		bChild.transform.localScale = transform.localScale/2;
		(bChild.GetComponent<Popping> ()).xSpeed = iniXSpeed;
													
	}

}
