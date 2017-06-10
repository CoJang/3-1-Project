using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz1 : MonoBehaviour
{
    [SerializeField] Sprite[] ItemList;
    [SerializeField] VariableBlock Block;
    [SerializeField] Gate m_Gate;
    [SerializeField] CameraMove m_CameraMove;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        CheckIsCorrect();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Item")
        {
            //print("Item Coll!" + other.gameObject.GetComponent<ItemScript>().GetBlockKey());

            other.gameObject.GetComponent<ItemScript>().BlockKey = "NULL";
            other.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().SetEquip(false);

            gameObject.GetComponent<SpriteRenderer>().sprite = ItemList[other.gameObject.GetComponent<ItemScript>().GetBlockSprNum()];
        }
    }

    virtual public bool CheckIsCorrect()
    {
        if (Block.Satisfied && gameObject.GetComponent<SpriteRenderer>().sprite == ItemList[6])
        {
            PuzzleSolved();
            return true;
        }
        else
            return false;
    }

    virtual protected void PuzzleSolved()
    {
        if (m_Gate.isOpen == false)
        {
            m_CameraMove.Move(m_Gate.transform.position, 0.5f, 1.0f, null);
            m_Gate.Open(0.3f);
        }

        PlayerPrefs.DeleteKey("BLOCK 6");
    }
}
