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
	public polarState thePolar;
	
	//We create a polar var
	private bool currPolarity = false;
	
	//Material References
	string refBlueMat = "materials/pulseBlue";
	string refRedMat = "materials/pulseRed";
	
	//We set up the strenght of the 
	public float polStrg = 20.0f;
	
	// Use this for initialization
	void Start () {
		thePolar = polarState.blue;

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
		
		
		
		
		//We make a vector 3 with the distance
		Vector3 rayTopDist = new Vector3(0,10,0);
		Vector3 rayBottomDist = new Vector3(0,-10,0);
		
		//We draw 2 rays one fo the bottom and one for the top;
        Debug.DrawRay(this.transform.position, rayTopDist, Color.green); 
		Debug.DrawRay(this.transform.position, rayBottomDist, Color.red); 
		
		
		
		//We check the ray up
		if(Physics.Raycast(this.transform.position, rayTopDist, out theHitTop) == true){
			
			checkPolarization(theHitTop, polStrg);
			
		}//End Ray Top
		
	
		//We check the Ray below
		if(Physics.Raycast(this.transform.position, rayBottomDist, out theHitBottom) == true){
			
			checkPolarization(theHitBottom,polStrg);
			
		}//End Bottom If
		
	}
	
	
	
	void checkPolarization(RaycastHit targRay, float thePolStrg){
		print("calling the fct");	
	
		//We check if the ray hit with a blue or red tag
		switch(targRay.transform.gameObject.tag){
			
			case"blueTag":
				
				if(thePolar == polarState.blue){
					//print ("framboise");
					rigidbody.AddForce (0,-thePolStrg,0);
				}else{
					rigidbody.AddForce (0,thePolStrg,0);
				}

				if(thePolar == polarState.red){
					//print ("chocolat");
					rigidbody.AddForce (0,thePolStrg,0);
				}else{
					rigidbody.AddForce (0,-thePolStrg,0);
				}
			
			break;
			
			case"redTag":
				
				if(thePolar == polarState.red){
					rigidbody.AddForce (0,-thePolStrg,0);
				}else{
					rigidbody.AddForce (0,thePolStrg,0);	
				}

				if(thePolar == polarState.blue){
					//We push it away
					rigidbody.AddForce (0,thePolStrg,0);
				}else{
					//We bring it closer 
					rigidbody.AddForce (0,-20,0);
				}
			
			break;
		}
		
	}
	
	
	////////////////////////////////////////
	//	On Collision
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
	
	
	
	
	////////////////////////////////////////
	//	On click
	void OnMouseDown(){
		
		
		//We change the polarity
		currPolarity = !currPolarity;	
		
		
		
		//We check for the current polarity state
		switch(currPolarity){
			
			//Becomes red
			case true:					
			
				//We change rhe color on the fly
				Material matRed = Resources.Load(refRedMat, typeof(Material)) as Material;		
				this.renderer.material = matRed;
				
				//We change the polarState
				thePolar = polarState.red;	
			
			break;
			
			
			//Becomes blue
			case false:				
				//We change rhe color on the fly
				Material matBlue = Resources.Load(refBlueMat, typeof(Material)) as Material;		
				this.renderer.material = matBlue;
				
				//We change the polarState
				thePolar = polarState.blue;	
			
			break;	
		}
		
		
	}
	
}
