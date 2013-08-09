using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	
	public float lifeSpan = 1.0f;
	public float currLifeSpan;
	public ParticleSystem explodePart;
	
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
		
		
		if(theCollision.transform.tag == "toDestroy"  || theCollision.transform.tag == "death"  || theCollision.transform.tag == "blueTag" || theCollision.transform.tag == "redTag" ){
			Invoke("selfDestroy", 0.06f);
		}
		
		
		/*switch(theCollision.transform.tag){
			case "toDestroy":
				Invoke("selfDestroy", 0.06f);
			break;
			case "death":
				Invoke("selfDestroy", 0.06f);
			break;
			case "blu":
				Invoke("selfDestroy", 0.06f);
			break;
		}*/
		
	}
	
	
	// Update is called once per frame
	void Update () {
		//currLifeSpan = Time.deltaTime*1;
	}
}
