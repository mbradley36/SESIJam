using UnityEngine;
using System.Collections;

public class TurretHandler : MonoBehaviour {
	private bool active;
	private float lastShot, beginCapture;
	private Vector2 fireDirection;
	private int playerOwnedBy;
	private GameObject buildEffect, shootEffect;

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
				if(beginCapture == 0f && !buildEffect) {
					beginCapture = Time.time;
					buildEffect = GameManager.instance.Rebuild(gameObject.transform.position);
				}
				if (Time.time - beginCapture > GameManager.instance.timeToBuild && !active) {
					active = true;
					playerOwnedBy = (int)pc.playerNum;
					GameManager.instance.buildCounts[playerOwnedBy] ++;
					GetComponent<BoxCollider2D>().isTrigger = false;
					Vector2 charPos = c.gameObject.transform.position;
					fireDirection = new Vector2(charPos.x - transform.position.x, charPos.y - transform.position.y);
					beginCapture = 0f;
					GameObject.Destroy(buildEffect);
					shootEffect = GameManager.instance.Fire(transform.position, fireDirection);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		beginCapture = 0f;
		if (buildEffect)
			GameObject.Destroy (buildEffect);
	}
}
