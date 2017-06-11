using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Coin : PuzzleInterface
{
    [SerializeField] VariableBlock[] Blocks;
    [SerializeField] PuzzleSlots Slot;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // 50 _ _ _ coin
    //Blocks[0].SprNum 0 * Blocks[1].SprNum 0 <
    //Blocks[0].SprNum 1 / Blocks[1].SprNum 1 >
    //Blocks[0].SprNum 2 + Blocks[1].SprNum 2 =
    //Blocks[0].SprNum 3 - 

    public override bool CheckIsCorrect()
    {
        // 50 * 7 = coin
        if(Blocks[0].SprNum == 0 && Slot.GetSpriteNum() == 7 && Blocks[1].SprNum == 2)
        {
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN", 0) + 350);
            PlayerPrefs.DeleteKey("BLOCK 7");
            return true;
        }

        // 50 / 7 = coin
        if (Blocks[0].SprNum == 1 && Slot.GetSpriteNum() == 7 && Blocks[1].SprNum == 2)
        {
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN", 0) + 7);
            PlayerPrefs.DeleteKey("BLOCK 7");
            return true;
        }

        // 50 + 7 = coin
        if (Blocks[0].SprNum == 2 && Slot.GetSpriteNum() == 7 && Blocks[1].SprNum == 2)
        {
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN", 0) + 57);
            PlayerPrefs.DeleteKey("BLOCK 7");
            return true;
        }

        // 50 - 7 = coin
        if (Blocks[0].SprNum == 3 && Slot.GetSpriteNum() == 7 && Blocks[1].SprNum == 2)
        {
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN", 0) + 43);
            PlayerPrefs.DeleteKey("BLOCK 7");
            return true;
        }
        else
            return false;
    }
}
