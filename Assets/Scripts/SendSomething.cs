using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSomething : MonoBehaviour
{
    public PuzzleInterface script;

    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.gameObject.tag == "Player" || Col.gameObject.tag == "Item")
        {
            script.CheckIsCorrect();
        }
    }
}
