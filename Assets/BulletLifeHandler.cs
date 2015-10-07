using UnityEngine;
using System.Collections;

public class BulletLifeHandler : MonoBehaviour {
	private float birth;

	// Use this for initialization
	void Start () {
		birth = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		if(Time.time - birth > 0.1f) Destroy (gameObject);
	}
}
