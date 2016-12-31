using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Model_Selector : MonoBehaviour {

	public List<GameObject> models;
	public static int SelectionIndex = 0;

	void Awake()
	{
		//DontDestroyOnLoad(SelectionIndex);
	}

	void Start()
	{
		models = new List<GameObject>();
		foreach(Transform t in transform)
		{
			models.Add(t.gameObject);
			t.gameObject.SetActive(false);
		}
		models[SelectionIndex].SetActive(true);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			Select(1);
		}
	}

	public void Select(int index)
	{
		if(index == SelectionIndex)
			return;
		if(index < 0 && index >= models.Count)
			return;
		models[SelectionIndex].SetActive(false);
		SelectionIndex = index;
		models[SelectionIndex].SetActive(true);
	}

	public void levelselector()
	{
		Application.LoadLevel("First_Stage");
	}

}
