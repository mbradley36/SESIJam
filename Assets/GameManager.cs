using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject playerPrefab;
	public Color[] playerColors = new Color[4];
	public float maxBerzerkTime;
	public float pauseBtwnBullets;

	private PlayerController[] players = new PlayerController[4];

	void Awake() {
		if (!instance) instance = this;
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Input.GetJoystickNames().Length; i++) {
			PlayerController pc = GameObject.Instantiate(playerPrefab).GetComponent<PlayerController>();
			players[i] = pc;
		}

		players[0].xAxis = "Horizontal_0";
		players [0].yAxis = "Vertical_0";

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
}
