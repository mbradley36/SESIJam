using UnityEngine;
using System.Collections;

public class BulletLifeHandler : MonoBehaviour {
	private float birth;
	public bool activeBullet;

	// Use this for initialization
	void Start () {
		birth = Time.time;
		activeBullet = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - birth > 0.1f)
			activeBullet = true;
	}

	void OnCollisionEnter2D(Collision2D c) {
		if(Time.time - birth > 0.1f) Destroy (gameObject);
	}
}
