using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    //GameObject player;
    //GameObject PlayerItemSlot;
    //PlayerMove playerScript;
    //[SerializeField] GameObject Get_effect;

   public string BlockKey;
   public int BlockSprNum;

    void Awake()
    {
        if (BlockKey == "BLOCK 0") BlockSprNum = 0;
        else if (BlockKey == "BLOCK 1") BlockSprNum = 1;
        else if (BlockKey == "BLOCK 2") BlockSprNum = 2;
        else if (BlockKey == "BLOCK 3") BlockSprNum = 3;
        else if (BlockKey == "BLOCK 4") BlockSprNum = 4;
        else if (BlockKey == "BLOCK 5") BlockSprNum = 5;
        else if (BlockKey == "BLOCK 6") BlockSprNum = 6;
        else if (BlockKey == "BLOCK 7") BlockSprNum = 7;
        else if (BlockKey == "BLOCK 8") BlockSprNum = 8;
        else if (BlockKey == "BLOCK 9") BlockSprNum = 9;
        else if (BlockKey == "BLOCK LEFT") BlockSprNum = 10;
        else if (BlockKey == "BLOCK RIGHT") BlockSprNum = 11;
        else if (BlockKey == "BLOCK EQUAL") BlockSprNum = 12;
        else if (BlockKey == "BLOCK PLUS") BlockSprNum = 13;
        else if (BlockKey == "BLOCK MINUS") BlockSprNum = 14;
        else if (BlockKey == "BLOCK DIVIDE") BlockSprNum = 15;
        else if (BlockKey == "BLOCK MULTY") BlockSprNum = 16;
        else if (BlockKey == "BLOCK FX") BlockSprNum = 17;
        else if (BlockKey == "BLOCK GX") BlockSprNum = 18;
        else if (BlockKey == "BLOCK HX") BlockSprNum = 19;
        else if (BlockKey == "BLOCK X") BlockSprNum = 20;
        else if (BlockKey == "BLOCK Y") BlockSprNum = 21;
        else if (BlockKey == "BLOCK Z") BlockSprNum = 22;
        else if (BlockKey == "BLOCK ROOT") BlockSprNum = 23;
        else BlockSprNum = 99;
    }

    void Start()
    {

    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if(col.gameObject.tag == "Player" && !playerScript.isItemHold)
    //    {
    //        transform.SetParent(PlayerItemSlot.transform);
    //        transform.localPosition = Vector3.zero;

    //        playerScript.isItemHold = true;
    //    }
    //}

    public string GetBlockKey()
    {
        return BlockKey;
    }

    public int GetBlockSprNum()
    {
        return BlockSprNum;
    }
}
