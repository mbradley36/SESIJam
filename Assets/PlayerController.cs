using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool bezerkState;
	private int playerNum;
	private Rigidbody2D rb;

	[HideInInspector]
	public string xAxis, yAxis;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = GameManager.instance.playerColors [playerNum];
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float xMovement = Input.GetAxis (xAxis);
		float yMovement = Input.GetAxis (yAxis);
		if (Mathf.Abs(xMovement) > 0.001f || Mathf.Abs(yMovement) > 0.001f) {
			rb.AddForce(new Vector2(xMovement, yMovement));
		}
	}
	
}
