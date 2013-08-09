using UnityEngine;
using System.Collections;

public class clearBar : MonoBehaviour {

	void OnTriggerEnter(Collider theTrigger){
		print("THE TRIGGER" + theTrigger );
		
		//If we touch the player we tell the gameManager to change state!
		if(theTrigger.transform.tag == "Player"){
			GameObject theGameManagerObj = GameObject.Find("_gameManager");
			theGameManagerObj.GetComponent<gameManager>().theCurrGameState = gameManager.gameState.gameOver;
		}
	}
	
}
