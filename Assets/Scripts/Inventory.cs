using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.GetInt("STAR", 0);
        PlayerPrefs.GetInt("COIN", 0);
        PlayerPrefs.GetInt("COLLECTION", 0);
        PlayerPrefs.GetInt("CHAR", 0);
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

        return true;
    }

    public string ShowInventory()
    {
        string Buffer = null;

        Buffer =  "///////////////////\n";
        Buffer += "//Inventory Start//\n\n";

        if (PlayerPrefs.GetInt("BLOCK 0") > 0)  Buffer += "[ BLOCK 0 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 1") > 0)  Buffer += "[ BLOCK 1 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 2") > 0)  Buffer += "[ BLOCK 2 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 3") > 0)  Buffer += "[ BLOCK 3 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 4") > 0)  Buffer += "[ BLOCK 4 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 5") > 0)  Buffer += "[ BLOCK 5 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 6") > 0)  Buffer += "[ BLOCK 6 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 7") > 0)  Buffer += "[ BLOCK 7 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 8") > 0)  Buffer += "[ BLOCK 8 ]\n";
        if (PlayerPrefs.GetInt("BLOCK 9") > 0)  Buffer += "[ BLOCK 9 ]\n";

        if (PlayerPrefs.GetInt("BLOCK LEFT") > 0) Buffer += "[ BLOCK > ]\n";
        if (PlayerPrefs.GetInt("BLOCK RIGHT") > 0) Buffer += "[ BLOCK < ]\n";
        if (PlayerPrefs.GetInt("BLOCK EQUAL") > 0) Buffer += "[ BLOCK = ]\n";
        if (PlayerPrefs.GetInt("BLOCK PLUS") > 0) Buffer += "[ BLOCK + ]\n";
        if (PlayerPrefs.GetInt("BLOCK MINUS") > 0) Buffer += "[ BLOCK - ]\n";
        if (PlayerPrefs.GetInt("BLOCK DIVIDE") > 0) Buffer += "[ BLOCK ÷ ]\n";
        if (PlayerPrefs.GetInt("BLOCK MULTY") > 0) Buffer += "[ BLOCK * ]\n";

        if (PlayerPrefs.GetInt("BLOCK FX") > 0) Buffer += "[ BLOCK f(x) ]\n";
        if (PlayerPrefs.GetInt("BLOCK GX") > 0) Buffer += "[ BLOCK g(x) ]\n";
        if (PlayerPrefs.GetInt("BLOCK HX") > 0) Buffer += "[ BLOCK h(x) ]\n";

        if (PlayerPrefs.GetInt("BLOCK X") > 0) Buffer += "[ BLOCK X ]\n";
        if (PlayerPrefs.GetInt("BLOCK Y") > 0) Buffer += "[ BLOCK Y ]\n";
        if (PlayerPrefs.GetInt("BLOCK Z") > 0) Buffer += "[ BLOCK Z ]\n";



        Buffer += "\n// Inventory End //";

        print(Buffer);
        return Buffer;
    }
}
