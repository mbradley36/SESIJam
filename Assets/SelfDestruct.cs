using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
    float birth;

	// Use this for initialization
	void Start () {
        birth = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - birth > 3f) Destroy(gameObject);
    }
}
