using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot_2 : MonoBehaviour {

    [SerializeField] Foothold[] m_Foothold; // 2
    [SerializeField] Tuto_Puzzle_2 m_puzzle;
    [SerializeField] PlayerMove Player;
    [SerializeField] ItemPickUp[] Blocks; // [0] = left [1] = right

    public enum SLOT_STATE
    {
        SLOT_EMPTY,
        RIGHT_ITEM_EQUIP,
        LFTE_ITEM_EQUIP,
    };

    SLOT_STATE SlotState;
    int i;

    void Start ()
    {
        SlotState = SLOT_STATE.SLOT_EMPTY;
    }

    public void CheckIsCorrect()
    {
        i = m_puzzle.GetSpriteNum();

        if (i > 5 && !m_Foothold[1].isUpside && SlotState == SLOT_STATE.RIGHT_ITEM_EQUIP) 
        {
            m_Foothold[1].MoveUp(0.3f);
            m_Foothold[0].MoveDown(0.3f);
            Player.isItemHold = false;
        }
        else if (i < 5 && !m_Foothold[0].isUpside && SlotState == SLOT_STATE.LFTE_ITEM_EQUIP)
        {
            m_Foothold[0].MoveUp(0.3f);
            m_Foothold[1].MoveDown(0.3f);
            Player.isItemHold = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Item_right")
        {
            Player.isItemHold = false;
            CheckIsCorrect();
            SlotState = SLOT_STATE.RIGHT_ITEM_EQUIP;
            col.gameObject.transform.position = transform.position;

            //Debug.Log("[< Block] is Equiped");
        }

        else if (col.gameObject.name == "Item_left")
        {
            Player.isItemHold = false;
            CheckIsCorrect();
            SlotState = SLOT_STATE.LFTE_ITEM_EQUIP;
            col.gameObject.transform.position = transform.position;
            //Debug.Log("[> Block] is Equiped");
        }

        //print("Player Hold Condition :" + Player.isItemHold);
        //print("Slot_2.IsEquiped :" + GetState());
    }

   public SLOT_STATE GetState() { return SlotState; }

    public void OnItemCollition()
    {
        StartCoroutine(DelayedInteraction());
    }

    IEnumerator DelayedInteraction()
    {
        if (Blocks[1].IsPickUped && SlotState == ItemSlot_2.SLOT_STATE.LFTE_ITEM_EQUIP)
        {  
            Player.isItemHold = false;
            Blocks[0].IsPickUped = false;
            Blocks[0].transform.position = Blocks[0].OriginPos;
            SlotState = SLOT_STATE.SLOT_EMPTY;
        }

        else if (Blocks[0].IsPickUped && SlotState == ItemSlot_2.SLOT_STATE.RIGHT_ITEM_EQUIP)
        {
            Player.isItemHold = false;
            Blocks[1].IsPickUped = false;
            Blocks[1].transform.position = Blocks[1].OriginPos;
            SlotState = SLOT_STATE.SLOT_EMPTY;
        }

        CheckIsCorrect();

        yield return new WaitForSeconds(1.0f);
    }
}
