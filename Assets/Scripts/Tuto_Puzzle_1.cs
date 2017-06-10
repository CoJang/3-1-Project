using UnityEngine;
using System.Collections;

public class Tuto_Puzzle_1 : BlockColCheck
{
    [SerializeField] Sprite[] m_Sprite; // = new Sprite[10];
    [SerializeField] Gate m_Gate;
    [SerializeField] CameraMove m_CameraMove;
    [SerializeField] GameObject Col_effect;
    [SerializeField] GameObject Add_effect;

    int i;
	
    protected override void OnBlockCollition()
    {
        Instantiate(Col_effect, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
        Instantiate(Add_effect, new Vector3(transform.position.x, transform.position.y + 0.47f, transform.position.z), Quaternion.identity);
        i = (++i) % 10;
        m_SR.sprite = m_Sprite[i];

        if(i == 5)
        {
            if(m_Gate.isOpen == false)
            {
                m_CameraMove.Move(m_Gate.transform.position, 0.5f, 1.0f, null);
                m_Gate.Open(0.3f);
            }
        }

    }

}
