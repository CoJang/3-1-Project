using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBackground : MonoBehaviour {
	public GameObject point;
	public SpriteRenderer background;
	public Sprite HighNoonBG;
	public Sprite NightBG;

	private bool ChangeCheck;



	// Use this for initialization
	void Start () {
		background.sprite = HighNoonBG;
		ChangeCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (point.transform.position.x <= transform.position.x) {
			background.sprite = changed;
		}
		*/
	}

	public void ChangeBG()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag.Equals ("Player")) {
			Debug.Log ("SDAWDAASDADAD");

			if (ChangeCheck == false) {
				background.sprite = NightBG;

				ChangeCheck = true;

				Debug.Log ("AAAAAAAAAAAAAAAAAAAAAAA");

			} else if (ChangeCheck == true) {
				background.sprite = HighNoonBG;

				ChangeCheck = false;

				Debug.Log ("BBBBBBBBBBBBBBBBBBBBBBB");
			}
		}
	}
}
