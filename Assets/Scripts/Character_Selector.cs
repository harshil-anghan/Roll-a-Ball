using UnityEngine;
using System.Collections;

public class Character_Selector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Model_Selector.SelectionIndex == 0)
		{
			GameObject.Find("AtomBall").SetActive(false);
			GameObject.Find("MetalBall").SetActive(false);
			print(Model_Selector.SelectionIndex);
		}
		else if(Model_Selector.SelectionIndex == 1)
		{
			GameObject.Find("WoodBall").SetActive(false);
			GameObject.Find("MetalBall").SetActive(false);
			print(Model_Selector.SelectionIndex);
		}
		else if(Model_Selector.SelectionIndex == 2)
		{
			GameObject.Find("WoodBall").SetActive(false);
			GameObject.Find("AtomBall").SetActive(false);
			print(Model_Selector.SelectionIndex);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
