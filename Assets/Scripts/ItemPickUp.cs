using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : BlockColCheck {

    [SerializeField] Transform PlayerPos;
    [SerializeField] Transform SlotPos;
    [SerializeField] PlayerMove Player;
    [SerializeField] ItemSlot_2 Slot_2;
    [SerializeField] ItemPickUp[] Blocks; // [0] = left [1] = right

    public Vector3 OriginPos;
    public bool IsPickUped;
    bool IsEquiped;

    // Use this for initialization
    void Start ()
    {
        IsPickUped = false;
        IsEquiped = false;
        OriginPos = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {   

        if (Player.isItemHold && IsPickUped && Slot_2.GetState() == ItemSlot_2.SLOT_STATE.SLOT_EMPTY)
        {
            transform.position = new Vector3(PlayerPos.position.x, PlayerPos.position.y + 1.25f, PlayerPos.position.z);                     
        }
        else
        {
            return;
        }
	}

    protected override void OnBlockCollition()
    {

        //if (!Player.isItemHold) // if Player is not Holding a Block
        //{
            IsPickUped = true;
        //}

        Slot_2.OnItemCollition();

        //print("Player Hold Condition :" + Player.isItemHold);
        //print("IsPickUped :" + IsPickUped);
        //print("Slot_2.IsEquiped :" + Slot_2.GetState());
        //print("IsEquiped :" + IsEquiped);

    }

    protected override void OnItemEquiption()
    {

        //Player.SetHoldCondition(false);
        //IsPickUped = false;
        IsEquiped = true;

        transform.position = SlotPos.position;

        

        //print("Player Hold Condition :" + Player.GetHoldCondition());
        //print("IsPickUped :" + IsPickUped);
        //print("IsEquiped :" + IsEquiped);
    }
}
