using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {
	
	private float currentGravity;
	
	// Use this for initialization
	void Start () {
		//gameObject.AddComponent<Rigidbody>();
		//gameObject.rigidbody.mass = 1;
		//this.rigidbody.AddRelativeForce (0, 10, 0);
		
	}
	
	void FixedUpdate(){
		//rigidbody.AddRelativeForce (Vector3.forward * 50);	
		rigidbody.AddRelativeForce(0, -10, 0);
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
