using UnityEngine;
using System.Collections;

public class testGyro : MonoBehaviour {
	
	
	
	 public float speed = 10.0F;
	public Vector3 forceVec;
	
	public Vector3 someOutputValue;
	public float movementScale;
	public Vector3 pos;
	public float sega = 0.00F;

	

	//La valeur que l'on veut reduire
	public int someValueToDecrease = 20000;
	public Vector3 dir;
	
	public bool someOnOffLeft = false;
	public bool someOnOffRight = false;
	
	
	
	
	
	// Use this for initialization
	void Start () {
		
		
		///Controls
		/*if (Input.GetKey (KeyCode.RightArrow)){
			this.transform.Translate(3f * Time.deltaTime,0,0,Space.Self);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)){
			this.transform.Translate(-3f * Time.deltaTime,0,0,Space.Self);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
		
		
		dir = Vector3.zero;
		dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;
		
        transform.Translate(dir * speed);
		
		someOutputValue = dir * 100;
		
		///////////////////////////////////////
		
		pos = transform.position;
       // pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * movementScale;
       // transform.position = pos;
	
		
		
	}
}
