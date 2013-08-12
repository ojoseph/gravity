using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	
	public enum gameState{
		none,
		initialize,
		playGame,
		gameOver
		
	}
	
	public gameState theCurrGameState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(theCurrGameState){
			
			case gameState.initialize:
			break;
			
			case gameState.playGame:
			break;
			
			case gameState.gameOver:
				//loadGameOverGameManager();
				StartCoroutine("loadGameOver");
			break;
		}
	}
	
	
	////////////////////////////////////////
	//	LoadGame Over
	/*public void loadGameOverGameManager(){
		//yield return new WaitForSeconds(0.5f);
		Application.LoadLevel("gameOver");	
	}*/
	
	
	IEnumerator loadGameOver(){
//		print("FROM COROUTINE");
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel("gameOver");
		theCurrGameState = gameState.none;
	}
}
