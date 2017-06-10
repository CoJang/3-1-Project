using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster" && !other.isTrigger)
        {
            other.gameObject.GetComponent<MonsterMove>().Die();
        }
    }
}
