using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : BlockColCheck {

    [SerializeField] Transform PlayerPos;
    [SerializeField] Transform SlotPos;
    [SerializeField] PlayerMove Player;
    [SerializeField] Vector3 OriginPos;
    //Vector3 OriginPos;
    bool IsPickUped;
    bool IsEquiped;

    // Use this for initialization
    void Start ()
    {
        IsPickUped = false;
        IsEquiped = false;
        //OriginPos = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {   

        if (Player.GetHoldCondition() && IsPickUped)
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

        if (!Player.GetHoldCondition()) // if Player is not Holding a Block
        {
            IsPickUped = true;
            Player.SetHoldCondition(true);
        }
        if (Player.GetHoldCondition() && !IsEquiped && IsPickUped) // if Player Holding a Block And Does not Equiped
        {
                                                                   // Can't Pick Up Item
        }                                                        
        //if (!Player.GetHoldCondition() && IsEquiped)               // if Player Used the Block and Want to take another Block
       // {
      //      transform.position = OriginPos;                        // Equiped Block Goes Original Position
      //      IsEquiped = false;
     //       IsPickUped = false;
     //       Player.SetHoldCondition(false);
     //   }

        print("Player Hold Condition :" + Player.GetHoldCondition());
        print("IsPickUped :" + IsPickUped);
        print("IsEquiped :" + IsEquiped);

    }

    protected override void OnItemEquiption()
    {

        Player.SetHoldCondition(false);
        IsPickUped = false;
        IsEquiped ^= true;

        transform.position = SlotPos.position;

        

        print("Player Hold Condition :" + Player.GetHoldCondition());
        print("IsPickUped :" + IsPickUped);
        print("IsEquiped :" + IsEquiped);
    }
}
