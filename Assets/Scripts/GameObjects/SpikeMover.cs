using UnityEngine;
using System.Collections;

public class SpikeMover : MonoBehaviour {
	public float delayTime;
	// Use this for initialization
	void Start () {
		StartCoroutine(Go() );
	}
	
	// Update is called once per frame
	IEnumerator Go()
	{
		while(true)
		{
			GetComponent<Animation>().Play();
			yield return new WaitForSeconds(2f);
		}
	}
}
