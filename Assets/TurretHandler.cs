using UnityEngine;
using System.Collections;

public class TurretHandler : MonoBehaviour {
	private bool active;
	private float lastShot, beginCapture;
	private Vector2 fireDirection;
	private int playerOwnedBy;

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
				GameManager.instance.InstantiateBullet (transform.position, fireDirection);
			}
		}
	}

	void OnTriggerStay2D(Collider2D c) {
		PlayerController pc = c.gameObject.GetComponent<PlayerController>();
		if(pc) {
			if(pc.InBuildZone()) {
				Debug.Log("dfajkle");
				if(beginCapture == 0f) beginCapture = Time.time;
				if (Time.time - beginCapture > GameManager.instance.timeToBuild) {
					active = true;
					playerOwnedBy = (int)pc.playerNum;
					GetComponent<BoxCollider2D>().isTrigger = false;
					Vector2 charPos = c.gameObject.transform.position;
					fireDirection = new Vector2(charPos.x - transform.position.x, charPos.y - transform.position.y);
					Debug.Log(fireDirection);
				}
			}
		}
	}
}
