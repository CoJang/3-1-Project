using UnityEngine;
using System.Collections;

public class OnNumBlockHit : BlockColCheck
{
    public Sprite [] sp = new Sprite[10];
    public GameObject Gate1;

    int i = 1;

    void Awake()
    {
        m_SR = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate ()
    {
	    if (i == 9)
        {
            Destroy(Gate1);
        }
	}

    protected override void OnBlockCollition()
    {
        m_SR.sprite = sp[i];

        if (i == 9) i = 0;
        else i++;
    }
}
