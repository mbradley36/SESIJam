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
	private float burnTime;

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
			UpdateBezerkMovement ();
		} else {
			UpdateBuilderMovement();
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
	}

	private void UpdateBuilderMovement() {
		if (Mathf.Abs(xMovement) > 0.001f || Mathf.Abs(yMovement) > 0.001f) {
			rb.AddForce(new Vector2(xMovement, yMovement)*GameManager.instance.playerSpeed);
		}
	}
	
}
