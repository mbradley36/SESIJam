using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject playerPrefab, bulletPrefab;
	public Color[] playerColors = new Color[4];
	public float maxBerzerkTime;
	public float pauseBtwnBullets;
	public float playerSpeed, bezerkSpeed, bulletForce, timeToBuild;

	private PlayerController[] players = new PlayerController[4];

	void Awake() {
		if (!instance) instance = this;
	}

	// Use this for initialization
	void Start () {
		//instantiate players
		for (int i = 0; i < Input.GetJoystickNames().Length; i++) {
			PlayerController pc = GameObject.Instantiate(playerPrefab).GetComponent<PlayerController>();
			players[i] = pc;
			pc.playerNum = (PlayerIndex)i;
		}

		//input setup
		if (players [0]) {
			players [0].xAxis = "Horizontal_0";
			players [0].yAxis = "Vertical_0";
		} else {
			Debug.LogWarning("NO PLAYER CONTROLLERS DETECTED");
		}

		if (players[1]) {
			players [1].xAxis = "Horizontal_1";
			players [1].yAxis = "Vertical_1";
		}

		if (players[2]) {
			players [2].xAxis = "Horizontal_2";
			players [2].yAxis = "Vertical_2";
		}

		if (players[3]) {
			players [3].xAxis = "Horizontal_3";
			players [3].yAxis = "Vertical_3";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InstantiateBullet(Vector3 position, Vector2 direction) {
		GameObject go = GameObject.Instantiate (bulletPrefab);
		go.transform.position = position;
		go.GetComponent<Rigidbody2D>().AddForce(direction*bulletForce);
	}
}
