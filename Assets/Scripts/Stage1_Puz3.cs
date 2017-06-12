using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz3 : PuzzleInterface
{

    [SerializeField] PuzzleSlots[] Slots;
    [SerializeField] GameObject    Circle;
    [SerializeField] CameraMove    m_CameraMove;

    public Transform CamPos;

    bool Invoked;

    void Awake ()
    {
        Circle.GetComponent<SpriteRenderer>().enabled = false;
        Circle.GetComponent<CircleCollider2D>().enabled = false;
        Circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Invoked = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckIsCorrect();
    }

    public override bool CheckIsCorrect()
    {
        if (Slots[0].Satisfied && Slots[1].Satisfied && !Invoked)
        {
            m_CameraMove.Move(CamPos.position, 2f, 0.5f, null);
            Circle.GetComponent<SpriteRenderer>().enabled = true;
            Circle.GetComponent<CircleCollider2D>().enabled = true;
            Circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Circle.GetComponent<AudioSource>().Play();
            Invoked = true;

            PlayerPrefs.DeleteKey("BLOCK ROOT");
            PlayerPrefs.DeleteKey("BLOCK 2");
            Audio.Play();

            return true;
        }
        else
            return false;
    }
}
