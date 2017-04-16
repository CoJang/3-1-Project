using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Puzzle_2 : BlockColCheck {
    
    [SerializeField] Sprite[] m_Sprite;     // 10 
    [SerializeField] ItemSlot_2 m_Slot;
    //[SerializeField] CameraMove m_CameraMove;
    

    int i;

    protected override void OnBlockCollition()
    {
        i = (++i) % 10;
        m_SR.sprite = m_Sprite[i];

        m_Slot.CheckIsCorrect();
    }

    public int GetSpriteNum() { return i; }

}
