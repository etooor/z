using UnityEngine;
using System.Collections;

//Shoot Movement
public class Mover : MonoBehaviour {

	public float speed;
	Transform trans;

	// Use this for initialization
	void Start () 
	{
		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		trans.Translate (0.0f, speed * Time.deltaTime ,0.0f);
	}
}
