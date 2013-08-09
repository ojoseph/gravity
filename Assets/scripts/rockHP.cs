using UnityEngine;
using System.Collections;

public class rockHP : MonoBehaviour {
	
	public int currentHp = 1;
	public bool lossHp = false;
	
	////////////////////////////////////////
	//	On Collision
	void OnCollisionEnter( Collision theCollision){
	 
		switch(theCollision.gameObject.tag){
			//We check what hit us ( in the future we can use different bullet types
			case "bullet":
			
				currentHp -=1;
				
				if(currentHp<=0){
					Destroy(gameObject);	
				}
			break;
		}
	}//End Collision Enter

	
}
