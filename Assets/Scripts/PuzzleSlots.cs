using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlots : MonoBehaviour
{
    [SerializeField] Sprite[] ItemList;

    public bool Satisfied;
    public int ConditionSprNum;
    int SprNum;

    // Use this for initialization
    void Start()
    {
        Satisfied = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Satisfied = CheckCorrect();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.GetComponent<ItemScript>().BlockKey = "NULL";
            other.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().SetEquip(false);

            gameObject.GetComponent<SpriteRenderer>().sprite = ItemList[other.gameObject.GetComponent<ItemScript>().GetBlockSprNum()];
            SprNum = other.gameObject.GetComponent<ItemScript>().GetBlockSprNum();
        }
    }

    bool CheckCorrect()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == ItemList[ConditionSprNum])
        {
            return true;
        }
        else
        {

            return false;
        }
    }

    public int GetSpriteNum()
    {
        return SprNum;
    }
}
