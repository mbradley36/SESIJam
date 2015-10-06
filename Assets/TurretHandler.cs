using UnityEngine;
using System.Collections;

public class TurretHandler : MonoBehaviour {
	private bool active;
	private float lastShot;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (Time.time - lastShot > GameManager.instance.pauseBtwnBullets) {
				lastShot = Time.time;
				GameManager.instance.InstantiateBullet (transform.position, direction);
			}
		}
	}

	void OnTriggerStay2D(Collider2D c) {
		PlayerController pc = c.gameObject.GetComponent<PlayerController>();
		if(pc) {
			if(pc.InBuildZone()) active = true;
		}
	}
}
