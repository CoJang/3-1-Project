using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour {

    Animator m_Ani;

	// Use this for initialization
	void Start ()
    {
        m_Ani = GetComponent<Animator>();
    }
	
    public void FinishStage()
    {
        m_Ani.SetTrigger("Clear");
    }
}
