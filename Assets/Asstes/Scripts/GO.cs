﻿
using UnityEngine;

public class GO : MonoBehaviour {

    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position;
	}
}
