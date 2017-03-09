using UnityEngine;
using System.Collections;

public class OnNumBlockHit : BlockColCheck
{
    [SerializeField] Sprite[] sp; // = new Sprite[10];
    [SerializeField] Gate m_Gate;
    [SerializeField] CameraMove m_CameraMove;

    int i;
	
    protected override void OnBlockCollition()
    {
        i = (++i) % 10;
        m_SR.sprite = sp[i];

        if(i == 8)
        {
            if(m_Gate.isOpen == false)
            {
                m_CameraMove.Move(m_Gate.transform.position, 0.5f, 1.0f, null);
                m_Gate.Open(0.3f);
            }
        }

        //if (i == 9) i = 0;
        //else i++;
    }
}
