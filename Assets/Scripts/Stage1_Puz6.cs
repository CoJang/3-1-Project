using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz6 : PuzzleInterface
{
    [SerializeField] GameObject FxBlock;
    [SerializeField] PuzzleSlots Slot;
    [SerializeField] GameObject Graph;

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
        if (Slot.Satisfied && FxBlock.GetComponent<FxBlock>().Satisfied)
        {
            Audio.Play();
            FxBlock.GetComponent<Animator>().SetTrigger("Satisfied");
            PlayerPrefs.DeleteKey("BLOCK MINUS");
            return true;
        }
        else
            return false;
    }
}
