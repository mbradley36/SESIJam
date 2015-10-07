using UnityEngine;
using System.Collections;

public class TurretHandler : MonoBehaviour {
	private bool active;
	private float lastShot, beginCapture;

	// Use this for initialization
	void Start () {
		active = false;
		beginCapture = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (Time.time - lastShot > GameManager.instance.pauseBtwnBullets) {
				lastShot = Time.time;
				GameManager.instance.InstantiateBullet (transform.position, transform.forward);
			}
		}
	}

	void OnTriggerStay2D(Collider2D c) {
		PlayerController pc = c.gameObject.GetComponent<PlayerController>();
		if(pc) {
			if(pc.InBuildZone()) {
				if(beginCapture == 0f) beginCapture = Time.time;
				StartCoroutine("TriggerBuild");
			}
		}
	}

	private IEnumerator TriggerBuild() {
		//build stuff
		if (Time.time - beginCapture > GameManager.instance.timeToBuild) {
			active = true;
		}
		yield return new WaitForSeconds(0.001f);
	}
}
