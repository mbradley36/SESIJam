﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

	private bool bezerkState;
	private Rigidbody2D rb;

	[HideInInspector]
	public string xAxis, yAxis, buildKey;
	public PlayerIndex playerNum;

	private float xMovement, yMovement;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = GameManager.instance.playerColors [(int)playerNum];
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		xMovement = Input.GetAxis (xAxis);
		yMovement = Input.GetAxis (yAxis);

		if (bezerkState) {
			UpdateBezerkMovement ();
		} else {
			UpdateBuilderMovement();
		}
	}

	public bool InBuildZone(){
		if (GamePad.GetState (playerNum).Buttons.A == ButtonState.Pressed) {
			Debug.Log ("build!");
			return true;
			//StartCoroutine("TriggerBuild");
		} else {
			return false;
		}
	}

	private IEnumerator TriggerBuild() {
		//build stuff
		yield return new WaitForSeconds(0.001f);
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
