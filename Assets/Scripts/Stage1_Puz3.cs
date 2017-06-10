using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz3 : MonoBehaviour {

    [SerializeField] PuzzleSlots[] Slots;
    [SerializeField] GameObject    Circle;
    [SerializeField] CameraMove    m_CameraMove;

    void Awake ()
    {
        Circle.GetComponent<CircleCollider2D>().enabled = false;
        Circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Slots[0].Satisfied && Slots[1].Satisfied)
        {
            m_CameraMove.Move(Circle.transform.position, 1f, 0.5f, null);
            Circle.GetComponent<CircleCollider2D>().enabled = true;
            Circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    }
}
