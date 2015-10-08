using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject playerPrefab, bulletPrefab,
						objectDestroyed, objectRebuild, 
                        shield, turretFire, startSprite, 
                        instructionSprite, spawnTransform, winText;
	public Color[] playerColors = new Color[4];
	public float minBerzerkTime, maxBerzerkTime;
	public float pauseBtwnBullets;
	public float playerSpeed, bezerkSpeed, bulletForce, timeToBuild, 
					shiledTimeLimit, shieldBurnTime, rotationSpeed, turretHealth, gameTimeLimit;
	private float lastBerzerk;
	public float berzerkTimer, gameStarted;
	private bool canBerzerk = true;

    [HideInInspector]
    public bool StartScreen, instructionScren;

	public int[] buildCounts = new int[4];

	private PlayerController[] players = new PlayerController[4];

	void Awake() {
		if (!instance) instance = this;
	}

	// Use this for initialization
	void Start () {
        StartScreen = true;
        instructionScren = false;
		for(int i = 0; i < buildCounts.Length; i++) {
			buildCounts[i] = -1;
		}

		//instantiate players
		for (int i = 0; i < Input.GetJoystickNames().Length; i++) {
			PlayerController pc = GameObject.Instantiate(playerPrefab).GetComponent<PlayerController>();
			players[i] = pc;
			pc.playerNum = (PlayerIndex)i;
			GameObject s = GameObject.Instantiate(shield);
			Renderer shieldRenderer = s.transform.GetChild(0).GetComponent<Renderer>();
			shieldRenderer.enabled = false;
			s.transform.position = pc.transform.position;
			s.transform.parent = pc.transform;
			pc.shield = shieldRenderer;
			buildCounts[i] = 0;
            pc.transform.position = spawnTransform.transform.position;
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

		lastBerzerk = Time.time;
		berzerkTimer = GetNewTimer ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - gameStarted > gameTimeLimit)
        {
            Debug.Log("game over");
            instructionScren = true;
            int max = 0;
            int playerID = 0;
            for (int i = 0; i < buildCounts.Length; i++)
            {
                if (buildCounts[i] > max)
                {
                    max = buildCounts[i];
                    playerID = i;
                }
            }

            if (playerID == 0)
            {
                winText.GetComponent<GUIText>().text = "Player 1 wins!";
            }
            else if (playerID == 1)
            {
                winText.GetComponent<GUIText>().text = "Player 2 wins!";

            }
            else if (playerID == 2)
            {
                winText.GetComponent<GUIText>().text = "Player 3 wins!";

            }
            else if (playerID == 3)
            {
                winText.GetComponent<GUIText>().text = "Player 4 wins!";
            }
        }

        if (Input.GetKeyDown("space") && instructionScren)
        {
            instructionScren = false;
            instructionSprite.GetComponent<Renderer>().enabled = false;
            instructionSprite.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetKeyDown("space") && StartScreen)
        {
            StartScreen = false;
            instructionScren = true;
            instructionSprite.GetComponent<Renderer>().enabled = true;
            startSprite.GetComponent<Renderer>().enabled = false;
            gameStarted = Time.time;
        }

        if (Time.time - lastBerzerk > berzerkTimer && canBerzerk) {
            ActivateBerzerk();
        }
    }

	float GetNewTimer() {
		return Random.Range (minBerzerkTime, maxBerzerkTime);
	}

	private void ActivateBerzerk() {
		int lowest = 9001;
		int playerNum = 0;

		for(int i = 0; i < buildCounts.Length; i++) {
			if(buildCounts[i] != -1 && buildCounts[i] < lowest) {
				if( lowest == buildCounts[i] ) return;
				playerNum = i;
				lowest = buildCounts[i];
			}
		}

		players[playerNum].ActivateBerzerk();
		canBerzerk = false;

	}

	public GameObject Rebuild(Vector3 position) {
		GameObject go = GameObject.Instantiate (objectRebuild);
		go.transform.position = position;
		return go;
	}

	public void DestroyCannon(Vector3 position) {
        (GameObject.Instantiate(objectDestroyed)).transform.position = position;
	}

	public void ResetBerzerkTimer() {
		canBerzerk = true;
		berzerkTimer = GetNewTimer();
		lastBerzerk = Time.time;
	}

	public GameObject Fire(Vector3 position, Vector3 direction) {
		GameObject effect = GameObject.Instantiate (turretFire);
		effect.transform.position = position;
		effect.transform.LookAt(direction);

		return effect;
	}

	public void InstantiateBullet(Vector3 position, Vector2 direction) {
		//start bullet fire and effect
		GameObject go = GameObject.Instantiate (bulletPrefab);
		go.transform.position = position;
		go.GetComponent<Rigidbody2D>().AddForce(direction*bulletForce);
	}
}
