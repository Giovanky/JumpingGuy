﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour {
    [Range (0f,0.20f)]
    public float parallaxSpeed = 0.02f;
    public GameObject UIIdle;
    public RawImage background;
    public RawImage platform;

    public enum GameState { Idle, Playing };
    public GameState gameState = GameState.Idle;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Empieza el juego
        if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))) {
            gameState = GameState.Playing;
            UIIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRun");
        }else if(gameState==GameState.Playing){
            Parallax();
       }        
	}

    void Parallax() {
        float finalspeed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalspeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(background.uvRect.x + finalspeed * 4, 0f, 1f, 1f);    
    }
}
