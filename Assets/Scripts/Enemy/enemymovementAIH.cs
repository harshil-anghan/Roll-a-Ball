﻿using UnityEngine;
using System.Collections;

public class enemymovementAIH : MonoBehaviour {
	Transform player;
	NavMeshAgent nav;
	// Use this for initialization
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		nav.SetDestination(player.position);
	}
}
