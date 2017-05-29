using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Puzzle_2 : BlockColCheck {
    
    [SerializeField] Sprite[] m_Sprite;     // 10 
    [SerializeField] ItemSlot_2 m_Slot;
    [SerializeField] GameObject Col_effect;
    [SerializeField] GameObject Add_effect;
    //[SerializeField] CameraMove m_CameraMove;
    

    int i;

    protected override void OnBlockCollition()
    {
        Instantiate(Col_effect, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
        Instantiate(Add_effect, new Vector3(transform.position.x, transform.position.y + 0.47f, transform.position.z), Quaternion.identity);

        i = (++i) % 10;
        m_SR.sprite = m_Sprite[i];

        m_Slot.CheckIsCorrect();
    }

    public int GetSpriteNum() { return i; }

}
