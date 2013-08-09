using UnityEngine;
using System.Collections;

public class rockHP : MonoBehaviour {
	
	public int currentHp = 1;
	public bool lossHp = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter( Collision theCollision){
	 
		switch(theCollision.gameObject.tag){
			case "bullet":
				currentHp -=1;
				print("I WAS SHOT");
				if(currentHp<=0){
					Destroy(gameObject);	
				}
				//Invoke("removeHp", 1.0f);
				//lossHp = true;
			break;
			
		}
	}
	
	
	void removeHp(){
		if(lossHp == false){
			currentHp -=1;
			lossHp = false;
		}
		
	}
	
	
	
}
