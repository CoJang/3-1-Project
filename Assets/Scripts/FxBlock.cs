﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxBlock : MonoBehaviour {

    public PuzzleInterface script;
    public bool Satisfied;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Satisfied = true;
            script.CheckIsCorrect();
        }
    }
}
