using UnityEngine;
using System.Collections;

public class PowerupRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (180,180,0) * Time.deltaTime);
	}
}
