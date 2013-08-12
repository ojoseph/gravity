using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public float camSpeed = 0.2f;
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(camSpeed * Time.deltaTime,0,0,Space.Self);
	}
}
