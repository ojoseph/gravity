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
		Invoke("selfDestroy", 0.06f);
		
	}
	
	
	// Update is called once per frame
	void Update () {
		//currLifeSpan = Time.deltaTime*1;
	}
}
