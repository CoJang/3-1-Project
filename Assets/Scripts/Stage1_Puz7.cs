using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz7 : MonoBehaviour
{
    [SerializeField] PuzzleSlots Slot;
    [SerializeField] Gate gate;
    AudioSource Audio;
    bool invoked;

	// Use this for initialization
	void Start ()
    {
        Audio = GetComponent<AudioSource>();
        invoked = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Slot.Satisfied && !invoked)
        {
            invoked = true;
            gate.Open(0.3f);
            Audio.Play();
            PlayerPrefs.DeleteKey("BLOCK 3");
        }
	}
}
