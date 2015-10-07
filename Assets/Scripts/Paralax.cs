using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = gameObject.transform.position;
		pos.x = Time.time * moveSpeed;
		gameObject.transform.position = pos;
	}
}
