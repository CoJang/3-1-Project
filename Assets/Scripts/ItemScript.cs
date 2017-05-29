using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    GameObject player;
    GameObject PlayerItemSlot;
    PlayerMove playerScript;
    //[SerializeField] GameObject Get_effect;

    public string BlockKey;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerItemSlot = GameObject.FindGameObjectWithTag("PlayerBlockSlot");

        playerScript = player.GetComponent<PlayerMove>();
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
}
