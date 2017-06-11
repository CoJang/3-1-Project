using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz7 : MonoBehaviour
{
    [SerializeField] PuzzleSlots Slot;
    [SerializeField] Gate gate;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Slot.Satisfied)
        {
            gate.Open(0.3f);
            PlayerPrefs.DeleteKey("BLOCK 3");
        }
	}
}
