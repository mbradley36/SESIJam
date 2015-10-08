using UnityEngine;
using System.Collections;

public class TurretHandler : MonoBehaviour {
	private bool active;
	private float lastShot, beginCapture;
	private Vector2 fireDirection;
	private int playerOwnedBy;
	private GameObject buildEffect, shootEffect;
    private Animation buildAnimation;
	private float health;
    public Transform bulletPos;

    public GameObject turretHead, turretColor;

	// Use this for initialization
	void Start () {
		active = false;
		beginCapture = 0f;
        buildAnimation = transform.parent.GetChild(2).GetComponent<Animation>();
       // Debug.Log(buildAnimation);
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (Time.time - lastShot > GameManager.instance.pauseBtwnBullets) {
				lastShot = Time.time;
				GameManager.instance.InstantiateBullet (bulletPos.position, fireDirection);
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
                    //ANIMATIONS START HERE
                    foreach (AnimationState AS in buildAnimation)
                    {
                        AS.speed = -1;

                    }
                    buildAnimation.Play();
                }

                float horz = pc.GetRotationX();
                float vert = pc.GetRotationY();
                if (Mathf.Abs(horz) > 0.1f || Mathf.Abs(vert) > 0.1f)
                {
                    float angleT = Mathf.Atan2(vert, horz) * Mathf.Rad2Deg;
                    turretHead.transform.localEulerAngles = new Vector3(0, -angleT, 0);
                    transform.eulerAngles = new Vector3(0, 0, angleT);
                    bulletPos.eulerAngles = new Vector3(0, 0, angleT);
                }


                if (Time.time - beginCapture > GameManager.instance.timeToBuild && !active) {
                    active = true;
                
					health = GameManager.instance.turretHealth;
					playerOwnedBy = (int)pc.playerNum;
                    turretColor.GetComponent<Renderer>().material.color = GameManager.instance.playerColors[playerOwnedBy];
                    GameManager.instance.buildCounts[playerOwnedBy] ++;
					GetComponent<BoxCollider2D>().isTrigger = false;
					Vector2 charPos = c.gameObject.transform.position;
                    fireDirection = transform.right;
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
        {
            GameObject.Destroy(buildEffect);
            buildAnimation.Stop();
        }
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.layer == LayerMask.NameToLayer("bullet")) {
			if(c.gameObject.GetComponent<BulletLifeHandler>().activeBullet) {
				health -= 1;
				Debug.Log("I've been hit!");
				if(health < 0) DeactivateTurret();
			}
		}
	}

	void DeactivateTurret(){
		Debug.Log("deactivating turret");
		active = false;
		GameManager.instance.buildCounts[playerOwnedBy] --;
        GameManager.instance.DestroyCannon(transform.position);
		GetComponent<BoxCollider2D>().isTrigger = true;
		GameObject.Destroy (shootEffect);
	}
}
