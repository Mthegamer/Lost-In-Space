﻿using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	bool invisibilePowerup = false;
	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find("Level Settings");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Asteroid")
		{
			if (invisibilePowerup == false)
			{
				gameObject.SendMessage("DestroyPlayer", SendMessageOptions.DontRequireReceiver);
			}
			else if (invisibilePowerup == true)
			{
				col.gameObject.SendMessage("DestroyAsteroid");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Coin")
		{
			Debug.Log("Score Coin");
			Destroy(col.gameObject);
			levelSettings.SendMessage("AddScore", 100);
		}
		if (col.gameObject.tag == "Star")
		{
			Debug.Log("Shield Power Up Enabled");
			GameObject shield = GameObject.Find("Shield");
			shield.SendMessage("EnableShield");
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == "Double")
		{
			Debug.Log ("Score Doubled");
			levelSettings.SendMessage("DoubleScore");
			Destroy(col.gameObject);
		}

	}
}
