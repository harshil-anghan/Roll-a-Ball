using UnityEngine;
using System.Collections;

public class DestroyFireBall : MonoBehaviour {
	float lifetime = 1.0f;
	// Use this for initialization
	void Awake () {
		Destroy(gameObject,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
