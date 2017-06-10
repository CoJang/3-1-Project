using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedItem : MonoBehaviour
{
    GameObject PlayerSlot;
    ItemScript Item;

	// Use this for initialization
	void Start ()
    {
        PlayerSlot = GameObject.FindGameObjectWithTag("PlayerBlockSlot");
        Item = GetComponent<ItemScript>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Item.BlockKey != "NULL")
        {
            transform.position = PlayerSlot.transform.position;
            transform.rotation = PlayerSlot.transform.rotation;

        }
        else
            Destroy(gameObject);
    }
}
