﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public float yMinLive = -10f;
	public Transform spawnPoint;
	public GameObject playerPrefab; 

	Player_Ctrl player;

	public float timeToRespawn = 2f;


	void Awake(){
		if (instance == null){
			instance = this;
		}
		else if (instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		if (player == null){
			RespawnPlayer();

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null) {
				player = obj.GetComponent<Player_Ctrl>();
			}
		}
		
	}

	public void RespawnPlayer(){
	Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}
	public void KillPlayer(){
		if(player != null){
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", timeToRespawn);
		}

	}
}
