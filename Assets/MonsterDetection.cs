using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetection : MonoBehaviour
{
    [SerializeField] GameObject Body;
    MonsterMove BodyScript;
    bool TargetDetected = false;
    GameObject Target;

    public bool IsDetected
    {
        get { return TargetDetected; }
    }

    public GameObject FindTarget
    {
        get { return Target; }
    }

    void Awake()
    {
        BodyScript = GetComponentInChildren<MonsterMove>();
    }

    void FixedUpdate()
    {
        transform.position = Body.transform.position;
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        //if (Col.gameObject.tag == "Player")
        //{
        //    TargetDetected = true;
        //}
    }

    void OnTriggerStay2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            Target = Col.gameObject;
            TargetDetected = true;
            //BodyScript.RadarAction();
        }
    }

    void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            TargetDetected = false;
           // BodyScript.RadarAction();
        }
    }

}
