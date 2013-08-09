using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {
	
	//We create a raycast
	public RaycastHit theHitTop;
	public RaycastHit theHitBottom;
	public RaycastHit theHitFront; //Will also serve for the gun
	public Ray theRayTop;
	public Ray theRayBottom;
	
	//We theStates the polar can be.
	public enum polarState{
		neutral,
		red,
		blue
	}
	
	//left us know from where we are dectecting
	enum direction{
		top,
		bottom	
	}
	
	//We create a polar state for the charater
	public polarState thePolar;
	
	//We create a polar var
	private bool currPolarity = false;
	
	//Material References
	string refBlueMat = "materials/pulseBlue";
	string refRedMat = "materials/pulseRed";
	
	//We set up the strenght of the 
	public float polStrg = 10.0f;
	
	
	//We set up the bullets
	public GameObject bullets;
	
	
	//........................................................................................................................................................
	
	
	
	
	
	
	
	////////////////////////////////////////
	//	Start
	void Start () {
		thePolar = polarState.blue;
	}
	
	////////////////////////////////////////
	//	Update
	void Update () {
		
		//Controls
		if (Input.GetKey (KeyCode.RightArrow)){
			this.transform.Translate(3f * Time.deltaTime,0,0,Space.Self);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)){
			this.transform.Translate(-3f * Time.deltaTime,0,0,Space.Self);
		}
		
		
		
		//........................................................................................................................................................
		
		
		
		//We make a vector 3 with the distance
		Vector3 rayTopDist = new Vector3(0,10,0);
		Vector3 rayBottomDist = new Vector3(0,-10,0);
		Vector3 rayFrontDist = new Vector3(10,0,0);
		
		//We draw 2 rays one fo the bottom and one for the top;
        Debug.DrawRay(this.transform.position, rayTopDist, Color.green); 
		Debug.DrawRay(this.transform.position, rayBottomDist, Color.red); 
		Debug.DrawRay(this.transform.position, rayFrontDist, Color.yellow);
		
		
		//We check the ray up
		if(Physics.Raycast(this.transform.position, rayTopDist, out theHitTop) == true){
			applyPolarization(theHitTop, polStrg,direction.top);
		}
		
	
		//We check the Ray below
		if(Physics.Raycast(this.transform.position, rayBottomDist, out theHitBottom) == true){
			applyPolarization(theHitBottom,polStrg,direction.bottom);
		}
		
		
		//We check the Ray infront for the gun
		if(Physics.Raycast(this.transform.position, rayFrontDist, out theHitFront) == true){
			//We check if the objec infront of us is a rock, if so we pull out the gun 
			if(theHitFront.transform.gameObject.tag == "toDestroy"){
				
				//We start Shooting
			}
		}
		
	}
	
	
	////////////////////////////////////////
	//	We Apply the Polarization
	void applyPolarization(RaycastHit targRay, float thePolStrg, direction theDir){
		
		//We do some corrections so that it works with both raycast
		if(theDir == direction.top){
			//There is a more appropriate aproach in my opinion
			thePolStrg = thePolStrg;
		}
		
		if(theDir == direction.bottom){
			//There is a more appropriate aproach in my opinion
			thePolStrg = -thePolStrg;
		}
		
		//We check if the ray hit with a blue or red tag
		switch(targRay.transform.gameObject.tag){

			//Might put a thirdStatus, neutral
			case"blueTag":
				
				if(thePolar == polarState.blue){
					//print ("framboise");
					rigidbody.AddForce (0,-thePolStrg,0);
				}else{
					rigidbody.AddForce (0,thePolStrg,0);
				}

			break;
			
			case"redTag":
				
				if(thePolar == polarState.red){
					rigidbody.AddForce (0,-thePolStrg,0);
				}else{
					rigidbody.AddForce (0,thePolStrg,0);	
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
				StartCoroutine("loadGameOver");
			break;
		}
		
		print ("Collision: " + theCollision.gameObject.name);
		
	}
	
	IEnumerator loadGameOver(){
		
		yield return new WaitForSeconds(1);
		
		Application.LoadLevel("gameOver");	
		
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
