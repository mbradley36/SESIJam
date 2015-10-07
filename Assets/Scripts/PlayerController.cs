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
	public float shieldUsed = 2f;

	private float xMovement, yMovement, shieldLeft;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = GameManager.instance.playerColors [(int)playerNum];
		rb = GetComponent<Rigidbody2D> ();
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

		if (GamePad.GetState (playerNum).Triggers.Left > 0.1f) {
			shield.enabled = true;
			gameObject.layer = LayerMask.NameToLayer("bulletIgnore");
		} else {
			shield.enabled = false;
			gameObject.layer = LayerMask.NameToLayer("Default");
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
