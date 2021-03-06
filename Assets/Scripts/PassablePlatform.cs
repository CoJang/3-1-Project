﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassablePlatform : MonoBehaviour {

	public GameObject GroundCheck;
	public float Height;

	void Start()
    {
		GroundCheck = GameObject.Find ("groundCheck");
	}

	void Update ()
	{
		if (GroundCheck.transform.position.y > gameObject.transform.position.y + Height)
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
		} 
		else
        {
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

}
