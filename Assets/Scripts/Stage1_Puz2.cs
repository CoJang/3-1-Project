using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz2 : MonoBehaviour
{
    [SerializeField] VariableBlock Block;
    [SerializeField] Gate m_Gate;
    [SerializeField] CameraMove m_CameraMove;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	void LateUpdate ()
    {
        CheckIsCorrect();
    }

    public bool CheckIsCorrect()
    {
        if (Block.Satisfied)
        {
            PuzzleSolved();
            return true;
        }
        else
            return false;
    }

    protected void PuzzleSolved()
    {
        if (m_Gate.isOpen == false)
        {
            m_CameraMove.Move(m_Gate.transform.position, 0.5f, 1.0f, null);
            m_Gate.Open(0.3f);
        }

        //PlayerPrefs.DeleteKey("BLOCK 6");
    }
}
