using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz5 : PuzzleInterface
{
    [SerializeField] GameObject Balance;
    [SerializeField] VariableBlock Variable;
    [SerializeField] VariableBlock Inequality;
    [SerializeField] CameraMove m_CameraMove;

    public Transform CamPos;

    //bool Invoked;

    void Awake()
    {
        Balance.GetComponent<Animator>().SetBool("Idle", true);
        Balance.GetComponent<Animator>().SetBool("DownRight", false);
        Balance.GetComponent<Animator>().SetBool("DownLeft", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool CheckIsCorrect()
    {
        if (Inequality.SprNum == 0 && Variable.SprNum > 5) // '5' < _
        {
            //print("[ Balance_DownRight ]");
            Balance.GetComponent<Animator>().SetBool("Idle", false);
            Balance.GetComponent<Animator>().SetBool("DownRight", true);
            Balance.GetComponent<Animator>().SetBool("DownLeft", false);
            return true;
        }
        else if (Inequality.SprNum == 1 && Variable.SprNum < 5) // '5' > _
        {
            //print("[ Balance_DownLeft ]");
            Balance.GetComponent<Animator>().SetBool("Idle", false);
            Balance.GetComponent<Animator>().SetBool("DownRight", false);
            Balance.GetComponent<Animator>().SetBool("DownLeft", true);
            return true;
        }
        else if (Inequality.SprNum == 2 && Variable.SprNum == 5) // '5' = _
        {
            //print("[ Balance_Idle ]");
            Balance.GetComponent<Animator>().SetBool("Idle", true);
            Balance.GetComponent<Animator>().SetBool("DownRight", false);
            Balance.GetComponent<Animator>().SetBool("DownLeft", false);
            return true;
        }
        else
            return false;
    }
}
