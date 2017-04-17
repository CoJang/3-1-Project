using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot_1 : MonoBehaviour {

    [SerializeField] PlayerMove Player;
    [SerializeField] GetItem m_Item3;
    public bool IsEquiped;

    int i;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Item_3")
        {
            col.gameObject.transform.position = transform.position;

            //Debug.Log("[< Block] is Equiped");
            Player.isItemHold = false;
            IsEquiped = true;
            m_Item3.DisableBlock();
            Debug.Log("Player.isItemHold " + Player.isItemHold);
            Debug.Log("IsActionable " + m_Item3.IsActionable);
        }
    }


}
