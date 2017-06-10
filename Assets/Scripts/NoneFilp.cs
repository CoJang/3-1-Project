using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneFilp : MonoBehaviour {

    SpriteRenderer Spr;
    public Transform PlayerBody;

	void Start ()
    {
        //PlayerBody = GetComponentInParent<Transform>();
        Spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerBody.localScale.x < 0)
        {
            Spr.flipX = true;
        }
        else
            Spr.flipX = false;

    }
}
