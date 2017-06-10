using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [SerializeField] Sprite [] UI_Blocks;
    [SerializeField] Image[] UI_Slots;
    [SerializeField] Image ItemBox;
    [SerializeField] SlotContrl slotContrl;

    [SerializeField] GameObject EmptyItem;
    PlayerMove player;

    void Start()
    {
        PlayerPrefs.GetInt("STAR", 0);
        PlayerPrefs.GetInt("COIN", 0);
        PlayerPrefs.GetInt("COLLECTION", 0);
        PlayerPrefs.GetInt("CHAR", 0);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        EmptyItem.GetComponent<SpriteRenderer>().sprite = null;
        EmptyItem.GetComponent<ItemScript>().BlockKey = "NULL";
    }

    /*
     *  Num 0 = NULL [ None ]
     *  Num 1 = HAVE
     *  Num 2~ = HAVING MULTY
     * 
     *  ////  Blocks //// [ KEY NAME ]
     *  BLOCK 0 ~ BLOCK 9
     *  BLOCK > [ BLOCK LEFT ]
     *  BLOCK < [ BLOCK RIGHT ]
     *  BLOCK X ,Y, Z
     *  BLOCK = [ BLOCK EQUAL ]
     *  BLOCK + [ BLOCK PLUS ]
     *  BLOCK - [ BLOCK MINUS ]
     *  BLOCK ÷ [ BLOCK DIVIDE ]
     *  BLOCK * [ BLOCK MULTY ]
     *  BLOCK f(x) [ BLOCK FX ] 
     *  BLOCK g(x) [ BLOCK GX ]
     *  BLOCK h(x) [ BLOCK HX ] 
     *  BLOCK ^    [ BLOCK ROOT ]
     */
    public bool CheckInventory(string _key) // if have a value, return true
    {
        if (PlayerPrefs.HasKey(_key))
            if (PlayerPrefs.GetInt(_key) == 0)
                return false;
            else
                return true;
        else
            return false;
    }

    public bool SaveItem(string _key, int count)
    {
        PlayerPrefs.SetInt(_key, count);
        PlayerPrefs.Save();

        if (PlayerPrefs.HasKey(_key))
            return true;
        else
            return false;
    }

    public bool DeleteItem(string _key) // if Successfully Delete, Return true
    {
        PlayerPrefs.DeleteKey(_key);
        PlayerPrefs.Save();

        if (!PlayerPrefs.HasKey(_key))
            return true;
        else
            return false;
    }

    public bool DeleteBlocks()
    {
        PlayerPrefs.DeleteKey("BLOCK 0");
        PlayerPrefs.DeleteKey("BLOCK 1");
        PlayerPrefs.DeleteKey("BLOCK 2");
        PlayerPrefs.DeleteKey("BLOCK 3");
        PlayerPrefs.DeleteKey("BLOCK 4");
        PlayerPrefs.DeleteKey("BLOCK 5");
        PlayerPrefs.DeleteKey("BLOCK 6");
        PlayerPrefs.DeleteKey("BLOCK 7");
        PlayerPrefs.DeleteKey("BLOCK 8");
        PlayerPrefs.DeleteKey("BLOCK 9");

        PlayerPrefs.DeleteKey("BLOCK LEFT");
        PlayerPrefs.DeleteKey("BLOCK RIGHT");
        PlayerPrefs.DeleteKey("BLOCK EQUAL");
        PlayerPrefs.DeleteKey("BLOCK PLUS");
        PlayerPrefs.DeleteKey("BLOCK MINUS");
        PlayerPrefs.DeleteKey("BLOCK DIVIDE");
        PlayerPrefs.DeleteKey("BLOCK MULTY");
        PlayerPrefs.DeleteKey("BLOCK FX");
        PlayerPrefs.DeleteKey("BLOCK GX");
        PlayerPrefs.DeleteKey("BLOCK HX");
        PlayerPrefs.DeleteKey("BLOCK X");
        PlayerPrefs.DeleteKey("BLOCK Y");
        PlayerPrefs.DeleteKey("BLOCK Z");
        PlayerPrefs.DeleteKey("BLOCK ROOT");

        PlayerPrefs.DeleteKey("SLOT 1");
        PlayerPrefs.DeleteKey("SLOT 2");
        PlayerPrefs.DeleteKey("SLOT 3");
        PlayerPrefs.DeleteKey("SLOT 4");
        PlayerPrefs.DeleteKey("SLOT 5");

        return true;
    }

    public void ShowInventory()
    {
        int count = 0;

        if (PlayerPrefs.GetInt("BLOCK 0") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[0]; PlayerPrefs.SetInt("SLOT " + count, 0); }
        if (PlayerPrefs.GetInt("BLOCK 1") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[1]; PlayerPrefs.SetInt("SLOT " + count, 1); }
        if (PlayerPrefs.GetInt("BLOCK 2") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[2]; PlayerPrefs.SetInt("SLOT " + count, 2); }
        if (PlayerPrefs.GetInt("BLOCK 3") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[3]; PlayerPrefs.SetInt("SLOT " + count, 3); }
        if (PlayerPrefs.GetInt("BLOCK 4") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[4]; PlayerPrefs.SetInt("SLOT " + count, 4); }
        if (PlayerPrefs.GetInt("BLOCK 5") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[5]; PlayerPrefs.SetInt("SLOT " + count, 5); }
        if (PlayerPrefs.GetInt("BLOCK 6") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[6]; PlayerPrefs.SetInt("SLOT " + count, 6); }
        if (PlayerPrefs.GetInt("BLOCK 7") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[7]; PlayerPrefs.SetInt("SLOT " + count, 7); }
        if (PlayerPrefs.GetInt("BLOCK 8") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[8]; PlayerPrefs.SetInt("SLOT " + count, 8); }
        if (PlayerPrefs.GetInt("BLOCK 9") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[9]; PlayerPrefs.SetInt("SLOT " + count, 9); }

        if (PlayerPrefs.GetInt("BLOCK LEFT") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[10]; PlayerPrefs.SetInt("SLOT " + count, 10); }
        if (PlayerPrefs.GetInt("BLOCK RIGHT") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[11]; PlayerPrefs.SetInt("SLOT " + count, 11); }
        if (PlayerPrefs.GetInt("BLOCK EQUAL") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[12]; PlayerPrefs.SetInt("SLOT " + count, 12); }
        if (PlayerPrefs.GetInt("BLOCK PLUS") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[13]; PlayerPrefs.SetInt("SLOT " + count, 13); }
        if (PlayerPrefs.GetInt("BLOCK MINUS") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[14]; PlayerPrefs.SetInt("SLOT " + count, 14); }
        if (PlayerPrefs.GetInt("BLOCK DIVIDE") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[15]; PlayerPrefs.SetInt("SLOT " + count, 15); }
        if (PlayerPrefs.GetInt("BLOCK MULTY") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[16]; PlayerPrefs.SetInt("SLOT " + count, 16); }

        if (PlayerPrefs.GetInt("BLOCK FX") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[17]; PlayerPrefs.SetInt("SLOT " + count, 17); }
        if (PlayerPrefs.GetInt("BLOCK GX") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[18]; PlayerPrefs.SetInt("SLOT " + count, 18); }
        if (PlayerPrefs.GetInt("BLOCK HX") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[19]; PlayerPrefs.SetInt("SLOT " + count, 19); }

        if (PlayerPrefs.GetInt("BLOCK X") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[20]; PlayerPrefs.SetInt("SLOT " + count, 20); }
        if (PlayerPrefs.GetInt("BLOCK Y") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[21]; PlayerPrefs.SetInt("SLOT " + count, 21); }
        if (PlayerPrefs.GetInt("BLOCK Z") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[22]; PlayerPrefs.SetInt("SLOT " + count, 22); }
        if (PlayerPrefs.GetInt("BLOCK ROOT") > 0 && count < 5) { UI_Slots[count].enabled = true; UI_Slots[count++].sprite = UI_Blocks[23]; PlayerPrefs.SetInt("SLOT " + count, 23); }

        slotContrl.ShotBlocks();
    }

    public void AddCoin()
    {
        int CoinNum = PlayerPrefs.GetInt("COIN");
        CoinNum++;
        PlayerPrefs.SetInt("COIN", CoinNum);
        PlayerPrefs.Save();
    }

    IEnumerator UpdateMove(Image Target, Vector3 dstPosition, float moveTime, float delayTime, Action callback)
    {
        Vector3 srcPosition = Target.rectTransform.anchoredPosition;
        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / moveTime)
        {
            Target.rectTransform.anchoredPosition = Vector3.Lerp(srcPosition, dstPosition, rate);
            yield return null;
        }
        yield return new WaitForSeconds(delayTime);
        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / moveTime)
        {
            Target.rectTransform.anchoredPosition = Vector3.Lerp(dstPosition, srcPosition, rate);
            yield return null;
        }
        if (callback != null)
            callback();
    }

    public GameObject CheckSlot(int slotNum)
    {
       // 
        //if(UI_Slots[slotNum].enabled)
        if (UI_Slots[slotNum].isActiveAndEnabled)
        {
            EmptyItem.GetComponent<SpriteRenderer>().sprite = UI_Blocks[PlayerPrefs.GetInt("SLOT " + (++slotNum))];
            EmptyItem.GetComponent<ItemScript>().BlockKey = GetBlockKey(PlayerPrefs.GetInt("SLOT " + (slotNum)));
            //player.SetEquip(true);
        }
        else
        {
            EmptyItem.GetComponent<SpriteRenderer>().sprite = null;
            EmptyItem.GetComponent<ItemScript>().BlockKey = "NULL";
            //player.SetEquip(false);
        }

        slotContrl.CollectBlocks();

        return EmptyItem;
    }

    public void CollectBlock()
    {
        slotContrl.CollectBlocks();

        for(int i = 0; i < 5; i++)
        {
            UI_Slots[i].enabled = false;
        }
    }

    public string GetBlockKey(int SprNum)
    {
        string BlockKey = "NULL";

        if (SprNum < 10)
            BlockKey = "BLOCK " + SprNum;
        else if (SprNum == 10) BlockKey = "BLOCK LEFT";
        else if (SprNum == 11) BlockKey = "BLOCK RIGHT";
        else if (SprNum == 12) BlockKey = "BLOCK EQUAL";
        else if( SprNum == 13) BlockKey = "BLOCK PLUS";
        else if (SprNum == 14) BlockKey = "BLOCK MINUS";
        else if (SprNum == 15) BlockKey = "BLOCK DIVIDE";
        else if (SprNum == 16) BlockKey = "BLOCK MULTY";
        else if (SprNum == 17) BlockKey = "BLOCK FX";
        else if (SprNum == 18) BlockKey = "BLOCK GX";
        else if (SprNum == 19) BlockKey = "BLOCK HX";
        else if (SprNum == 20) BlockKey = "BLOCK X";
        else if (SprNum == 21) BlockKey = "BLOCK Y";
        else if (SprNum == 22) BlockKey = "BLOCK Z";
        else if (SprNum == 23) BlockKey = "BLOCK ROOT";

        return BlockKey;
    }
}

