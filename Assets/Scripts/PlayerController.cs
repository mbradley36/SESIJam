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

	private float xMovement, yMovement, shieldLeft;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = GameManager.instance.playerColors [(int)playerNum];
		rb = GetComponent<Rigidbody2D> ();
		burnTime = Time.time + GameManager.instance.shieldBurnTime;
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

		if(Time.time - lastBulletTime > GameManager.instance.pauseBtwnBullets/2f) {
			Vector3 gunLocation = transform.position;
			//gunLocation.x += 5;
			GameManager.instance.InstantiateBullet (gunLocation, new Vector3(1,1,0));
			lastBulletTime = Time.time;
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
		gameObject.layer = LayerMask.NameToLayer("bulletIgnore");
		gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("bulletIgnore");
		gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("bulletIgnore");
		bezerkState = true;
		lastBulletTime = Time.time;
	}

	public void DeactivateBerzerk() {
		gameObject.layer = LayerMask.NameToLayer("Default");
		gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
		gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
		bezerkState = false;
	}
	
}
