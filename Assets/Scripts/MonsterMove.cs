using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float movePower = 1f;

    Rigidbody2D m_Rigidbody;
    Vector2 JumpPower = new Vector2(0, 1f);
    public int movementFlag = 1; // iDle = 0, Left = 1; Right = 2, Tracing = 3;
    Vector3 moveDir = Vector3.zero;

    GameObject TraceTarget;
    [SerializeField] GameObject Father;
    MonsterDetection Radar;

    // Use this for initialization
    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        Radar = GetComponentInParent<MonsterDetection>();
        //Radar = GetComponentInChildren<MonsterDetection>();
        //Radar = GetComponent<MonsterDetection>();
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
                movePower = 1f;
                MoveLeft();
                break;
            case 2:
                movePower = 1f;
                MoveRight();
                break;
            case 3:
                Vector3 TargetPos = TraceTarget.transform.position;

                movePower = 5f;

                if (TargetPos.x < transform.position.x - 0.1f)
                    MoveLeft();
                else if (TargetPos.x > transform.position.x + 0.1f)
                    MoveRight();
                else
                    moveDir = Vector3.zero;

                break;
        }

        transform.position += moveDir * movePower * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.gameObject.tag == "BounceWall")
        {
            //print("coolll");
            switch(movementFlag)
            {
                case 0: // idle
                    break;

                case 1: // Left
                    movementFlag = 2;
                    MoveRight();
                    break;

                case 2: // Right
                    movementFlag = 1;
                    MoveLeft();
                    break;

                case 3: // Tracing
                    if (transform.localScale.x > 0)
                        movementFlag = 2;
                    else
                        movementFlag = 1;
                    break;
            }
        }
    }

    void OnTriggerStay2D(Collider2D Col)
    {

        if(movementFlag != 0)
            if (Col.gameObject.tag == "Player")
            {
                TraceTarget = Col.gameObject;
                movementFlag = 3;
            }
    }

    void OnTriggerExit2D(Collider2D Col)
    {
        if (movementFlag != 0)
            if (Col.gameObject.tag == "Player")
            {
                StartCoroutine(ChangeMovement());
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
        movementFlag = 0;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y * 0.6f, 1); // Y axis flip

        BoxCollider2D[] Coll = gameObject.GetComponents<BoxCollider2D>();
        if(Coll[0])
            Coll[0].enabled = false;
        if (Coll[1])
            Coll[1].enabled = false;

        BoxCollider2D ChildColl = gameObject.GetComponentInChildren<BoxCollider2D>();
        if(ChildColl)
            ChildColl.enabled = false;

        m_Rigidbody.AddForce(new Vector2(0, 5.5f), ForceMode2D.Impulse);

        Destroy(Father, 4f);
    }

    void MoveLeft()
    {
        moveDir = Vector3.left;
        transform.localScale = new Vector3(0.15f, transform.localScale.y, 1); // flip
    }

    void MoveRight()
    {
        moveDir = Vector3.right;
        transform.localScale = new Vector3(-0.15f, transform.localScale.y, 1); // flip
    }

    IEnumerator ChangeMovement()
    {
        if (movementFlag == 0)
           yield return 0;

        yield return new WaitForSeconds(3.0f);

        if (transform.localScale.x > 0)
            movementFlag = 1;
        else
            movementFlag = 2;
    }
}
