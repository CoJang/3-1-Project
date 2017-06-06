using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBounce : MonoBehaviour
{
    public int MonsterType;
    MonsterMove MonsterScript;
    GameObject MonsterBody;

	// Use this for initialization
	void Awake ()
    {
        if (MonsterType == 1)
        {
            MonsterBody = GameObject.Find("Monster B");
        }
        else
            MonsterBody = GameObject.Find("AirMonster");

        MonsterScript = MonsterBody.GetComponentInChildren<MonsterMove>();
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Monster" && !Col.isTrigger)
        {
            switch (MonsterScript.movementFlag)
            {
                case 0: // idle
                    break;

                case 1: // Left
                    MonsterScript.movementFlag = 2;
                    break;

                case 2: // Right
                    MonsterScript.movementFlag = 1;
                    break;

                case 3: // Tracing
                    if (MonsterBody.transform.localScale.x > 0)
                        MonsterScript.movementFlag = 2;
                    else
                        MonsterScript.movementFlag = 1;
                    break;
            }
        }
    }
}
