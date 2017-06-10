using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : BlockColCheck
{
    Animator Ani;

	void Awake ()
    {
        Ani = GetComponent<Animator>();	
	}

    // When Player Collision On This Block
    protected override void OnBlockCollition()
    {
        Ani.SetTrigger("Touched");
    }
}
