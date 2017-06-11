using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz6 : PuzzleInterface
{
    [SerializeField] GameObject FxBlock;
    [SerializeField] PuzzleSlots Slot;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override bool CheckIsCorrect()
    {
        if (Slot.Satisfied)
        {
            FxBlock.GetComponent<Animator>().SetTrigger("Satisfied");
            return true;
        }
        else
            return false;
    }
}
