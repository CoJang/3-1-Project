using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    public Text tex;

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.GetInt("STAR", 0);
        tex.text = "" + PlayerPrefs.GetInt("COIN", 0);
        PlayerPrefs.GetInt("COLLECTION", 0);
        PlayerPrefs.GetInt("CHAR", 0);


    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
