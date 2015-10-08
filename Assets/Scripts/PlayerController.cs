using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

	private bool bezerkState;
	private Rigidbody2D rb;

	[HideInInspector]
	public string xAxis, yAxis, buildKey;
	[HideInInspector]
	public PlayerIndex playerNum;
	[HideInInspector]
	public Renderer shield;
	[HideInInspector]
	public float shieldUsed = 0f;
	private bool shieldBurnOut;
	private float burnTime, lastBulletTime, berzerkStart;
	private Transform cannon1, cannon2;

    private Renderer berzerk, normal;

	private float xMovement, yMovement, shieldLeft;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = GameManager.instance.playerColors [(int)playerNum];
		rb = GetComponent<Rigidbody2D> ();
		burnTime = Time.time + GameManager.instance.shieldBurnTime;
		cannon1 = transform.GetChild (0);
        cannon2 = transform.GetChild(1);
        berzerk = transform.GetChild(2).GetComponent<Renderer>();
        normal = transform.GetChild(3).GetComponent<Renderer>();

        berzerk.enabled = false;
        normal.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

		xMovement = GamePad.GetState(playerNum).ThumbSticks.Left.X;
		yMovement = GamePad.GetState(playerNum).ThumbSticks.Left.Y;

		if (bezerkState) {
			if(Time.time - berzerkStart > GameManager.instance.berzerkTimer) {
				DeactivateBerzerk();
				GameManager.instance.ResetBerzerkTimer();
				UpdateBuilderMovement();
			} else {
				UpdateBezerkMovement ();
			}
		} else {
			UpdateBuilderMovement();
		}
	}

	public bool InBuildZone(){
		if (GamePad.GetState (playerNum).Buttons.A == ButtonState.Pressed) {
			return true;
		} else {
			return false;
		}
	}

	private void UpdateBezerkMovement() {
		if (Mathf.Abs(xMovement) > 0.001f || Mathf.Abs(yMovement) > 0.001f) {
			rb.AddForce(new Vector2(xMovement, yMovement)*GameManager.instance.bezerkSpeed);
		}

		if(Time.time - lastBulletTime > GameManager.instance.pauseBtwnBullets/5f) {
			Vector3 gunLocation = transform.position;
			Vector3 shootDir = new Vector3(forward.position.x - transform.position.x, 
			                               forward.position.y - transform.position.y, 
			                               forward.position.y - transform.position.z);
			GameManager.instance.InstantiateBullet (forward.position, shootDir);
			lastBulletTime = Time.time;
		}

		float fwdRotation = GamePad.GetState(playerNum).ThumbSticks.Right.X;
		if (Mathf.Abs(fwdRotation) > 0.1f) {
			forward.RotateAround(transform.position, Vector3.forward, GameManager.instance.rotationSpeed*fwdRotation*Time.deltaTime);
		}
	}

	private void UpdateBuilderMovement() {
		if (Mathf.Abs(xMovement) > 0.001f || Mathf.Abs(yMovement) > 0.001f) {
			rb.AddForce(new Vector2(xMovement, yMovement)*GameManager.instance.playerSpeed);
		}

		if (GamePad.GetState (playerNum).Triggers.Left > 0.1f && shieldUsed < GameManager.instance.shiledTimeLimit) {
			shield.enabled = true;
			shieldUsed += 0.1f;
			gameObject.layer = LayerMask.NameToLayer("bulletIgnore");
		} else if(shieldUsed > GameManager.instance.shiledTimeLimit){
			shieldBurnOut = true;
			shield.enabled = false;
			gameObject.layer = LayerMask.NameToLayer("Default");
			burnTime = Time.time;
			shieldUsed = GameManager.instance.shiledTimeLimit;
		} else {
			if(shieldBurnOut && Time.time - burnTime > GameManager.instance.shieldBurnTime) {
				shieldBurnOut = false;
				shieldUsed = 0f;
			} else {
				shield.enabled = false;
				gameObject.layer = LayerMask.NameToLayer("Default");
			}
		}
	}

	public void ActivateBerzerk() {
		bezerkState = true;
		berzerkStart = Time.time;
		lastBulletTime = Time.time;

        berzerk.enabled = true;
        normal.enabled = false;
    }

	public void DeactivateBerzerk() {
		bezerkState = false;

        berzerk.enabled = false;
        normal.enabled = true;
    }
	
}
