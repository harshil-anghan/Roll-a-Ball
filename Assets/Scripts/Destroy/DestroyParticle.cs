using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {
	public float lifetime = 0;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
