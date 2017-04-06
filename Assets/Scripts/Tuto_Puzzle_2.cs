using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Puzzle_2 : BlockColCheck {
    
    [SerializeField] Sprite[] m_Sprite; // 10
    [SerializeField] Foothold[] m_Foothold; // 2
    [SerializeField] CameraMove m_CameraMove;

    int i;

    protected override void OnBlockCollition()
    {
        i = (++i) % 10;
        m_SR.sprite = m_Sprite[i];

        if(i > 5 && !m_Foothold[1].isUpside) // should check [ > or < is correct ] Later
        {
            m_Foothold[1].MoveUp(0.3f);
            m_Foothold[0].MoveDown(0.3f);
        }
        else if (i < 5 && !m_Foothold[0].isUpside)
        {
            m_Foothold[0].MoveUp(0.3f);
            m_Foothold[1].MoveDown(0.3f);
        }
    }

}
