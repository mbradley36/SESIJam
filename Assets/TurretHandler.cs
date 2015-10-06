using UnityEngine;
using System.Collections;

public class TurretHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		PlayerController pc = c.gameObject.GetComponent<PlayerController>();
		if(pc) pc.InBuildZone();
	}
}
