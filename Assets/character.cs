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
			//print("WE HIT SOMETHING "+ theHitTop.transform.gameObject.name);
			//print(theHitTop.transform.gameObject.tag);
			
			if(theHitTop.transform.gameObject.tag == "blueTag"){
			
				if(thePolar == polarState.blue){
					print ("framboise");
					rigidbody.AddForce (0,-20,0);
				}else{
					rigidbody.AddForce (0,20,0);
					
							
					}

				if(thePolar == polarState.red){
					print ("chocolat");
					rigidbody.AddForce (0,20,0);
				}else{
					rigidbody.AddForce (0,-20,0);
					
				}

			}
			
			
			
			
			if(theHitTop.transform.gameObject.tag == "redTag"){
			
				if(thePolar == polarState.red){
					print ("bleut");
					rigidbody.AddForce (0,-20,0);
				}else{
					rigidbody.AddForce (0,20,0);
					
							
					}

				if(thePolar == polarState.blue){
					print ("vanille");
					rigidbody.AddForce (0,20,0);
				}else{
					rigidbody.AddForce (0,-20,0);
					
				}

			}
			
			
			
			
			
			
			
		}//End Ray Top
		
		
		
		
		
		
		
		
		//We check the Ray below
		if(Physics.Raycast(this.transform.position, rayBottomDist, out theHitBottom) == true){
			//print("WE HIT SOMETHING "+ theHitBottom.transform.gameObject.name);
		
			//We check if there is a redTag below, if so we react according to it
			if(theHitBottom.transform.gameObject.tag == "redTag"){
			
				if(thePolar == polarState.red){
					//We push it away
					rigidbody.AddForce (0,20,0);
				}else{
					//We bring it closer 
					rigidbody.AddForce (0,-20,0);
				}
			}
			
			
			//We check if there is a blueTag below, if so we react according to it
			if(theHitBottom.transform.gameObject.tag == "blueTag"){
				
				if(thePolar == polarState.blue){
					//We push it away
					rigidbody.AddForce (0,20,0);
				}else{
					//We bring it closer 
					rigidbody.AddForce (0,-20,0);
				}

			}
			
		}//End Bottom If
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
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
