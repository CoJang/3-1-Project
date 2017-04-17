using UnityEngine;
using System.Collections;

public class Tuto_Puzzle_1 : BlockColCheck
{
    [SerializeField] Sprite[] m_Sprite; // = new Sprite[10];
    [SerializeField] Gate m_Gate;
    [SerializeField] CameraMove m_CameraMove;
    [SerializeField] ItemSlot_1 m_Slot1;

    int i;
	
    protected override void OnBlockCollition()
    {
        i = (++i) % 10;
        m_SR.sprite = m_Sprite[i];

        if(i == 5 && m_Slot1.IsEquiped)
        {
            if(m_Gate.isOpen == false)
            {
                m_CameraMove.Move(m_Gate.transform.position, 0.5f, 1.0f, null);
                m_Gate.Open(0.3f);
                m_Slot1.IsEquiped = false;
            }
        }

        //if (i == 9) i = 0;
        //else i++;
    }

}
