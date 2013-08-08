using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {
	
	//We create a raycast
	public RaycastHit theHitTop;
	public RaycastHit theHitBottom;
	public Ray theRayTop;
	public Ray theRayBottom;
	
	public enum polarState{
		neutral,
		red,
		blue
	}
	
	//We create a polar state for the charater
	public polarState thePolar = polarState.blue;
	private int currPolarity = 0;
	
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.RightArrow)){
			//Vector3 theMov = new Vector3(10,0,0);
			this.transform.Translate(2f * Time.deltaTime,0,0,Space.Self) ;
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)){
			//Vector3 theMov = new Vector3(10,0,0);
			this.transform.Translate(-2f * Time.deltaTime,0,0,Space.Self) ;
		}
		
		
		
		
		//We make a vector 3
		Vector3 rayTopDist = new Vector3(0,10,0);
		Vector3 rayBottomDist = new Vector3(0,-10,0);
		
		//We draw 2 rays one fo the bottom and one for the top;
        Debug.DrawRay(this.transform.position, rayTopDist, Color.green); 
		Debug.DrawRay(this.transform.position, rayBottomDist, Color.red); 
		
		if(Physics.Raycast(this.transform.position, rayBottomDist, out theHitBottom) == true){
			//print("WE HIT SOMETHING "+ theHitBottom.transform.gameObject.name);
			//rigidbody.AddForce (0,-10,0);
			
			if(theHitBottom.transform.gameObject.tag == "redTag"){
				//rigidbody.AddForce (0,10,0);
				//print("AAAAAA");
				rigidbody.AddForce (0,-20,0);
				if(thePolar == polarState.red){
					print ("YELLOW");
					rigidbody.AddForce (0,-60,0);
				}
			}
		}
		
		if(Physics.Raycast(this.transform.position, rayTopDist, out theHitTop) == true){
			//print("WE HIT SOMETHING "+ theHitTop.transform.gameObject.name);
			//print(theHitTop.transform.gameObject.tag);
			
			if(theHitTop.transform.gameObject.tag == "blueTag"){
				//rigidbody.AddForce (0,10,0);
				//print("AAAAAA");
				rigidbody.AddForce (0,20,0);
			}
		}
		
		
	}
	
	void OnCollisionEnter( Collision theCollision){
		/*if(theCollision.gameObject.name == "theCeiling"){
			print ("Collision: " + theCollision.gameObject.name);
		}*/ 
		switch(theCollision.gameObject.name){
			case "death":
				print("YOU DIED!");
			this.renderer.material.color = Color.red;
			break;
		}
		
		print ("Collision: " + theCollision.gameObject.name);
		
	}
	
	void OnMouseDown(){
		print("mouseClick");
		
		//We change the polarity upon mouse click
		currPolarity += 1;
		if(currPolarity >= 3){
			currPolarity =0;	
		}
		
		this.renderer.material.color = Color.yellow;
		thePolar = polarState.red;
	}
	
}
