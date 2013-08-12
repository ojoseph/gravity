using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	
	public float lifeSpan = 1.0f;
	public float currLifeSpan;
	public ParticleSystem explodePart;
	
	//List of items that will put the game over
	string[] deathCollision = {"toDestroy", "death", "blueTag", "redTag"};
	
	// Use this for initialization
	void Start () {
		explodePart.enableEmission = true;
			Invoke("selfDestroy", 3.0f);
		
	}
	
	
	void selfDestroy(){
		//We desstroy ourlself
		Destroy(gameObject);
		explodePart.enableEmission = true;
	}
	
	void OnCollisionEnter( Collision theCollision){
		
		//We  check if the bullet hits with a object that will put him game over
		foreach ( string item in deathCollision){
			//If we get a match we end the game and break out the loop
			if(theCollision.transform.tag == item){
				Invoke("selfDestroy", 0.06f);
				break;
			} 
		}

	}
	
}
