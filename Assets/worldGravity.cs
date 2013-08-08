using UnityEngine;
using System.Collections;

public class worldGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(0, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
