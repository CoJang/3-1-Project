using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float movePower = 1f;

    Rigidbody2D m_Rigidbody;
    Vector2 JumpPower = new Vector2(0, 2f);
    int movementFlag = 1; // iDle = 0, Left = 1; Right = 2, Die = 3;
    Vector3 moveDir = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
	}

    void Move()
    {
        moveDir = Vector3.zero;

        switch (movementFlag)
        {
            case 0:
                break;
            case 1:
                moveDir = Vector3.left;
                transform.localScale = new Vector3(0.15f, transform.localScale.y, 1); // flip
                break;
            case 2:
                moveDir = Vector3.right;
                transform.localScale = new Vector3(-0.15f, transform.localScale.y, 1); // flip
                break;
            case 3:
                return;
        }

        transform.position += moveDir * movePower * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.gameObject.tag == "BounceWall")
        {
            switch(movementFlag)
            {
                case 0: // idle

                    break;

                case 1: // Left
                    movementFlag = 2;
                    break;

                case 2: // Right
                    movementFlag = 1;
                    break;
            }
        }

    }

    IEnumerator Jump()
    {
        m_Rigidbody.AddForce(JumpPower, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);

        StartCoroutine(Jump());
    }

    public void Die()
    {
        StopCoroutine(Jump());
        movementFlag = 3;
        transform.localScale = new Vector3(transform.localScale.x, -0.15f, 1); // Y axis flip

        BoxCollider2D[] Coll = gameObject.GetComponents<BoxCollider2D>();
        Coll[0].enabled = false;
        Coll[1].enabled = false;

        BoxCollider2D ChildColl = gameObject.GetComponentInChildren<BoxCollider2D>();
        ChildColl.enabled = false;

        m_Rigidbody.AddForce(new Vector2(0, 5.5f), ForceMode2D.Impulse);

        Destroy(gameObject, 4f);
    }
}
