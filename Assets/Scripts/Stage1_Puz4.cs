using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz4 : MonoBehaviour
{
    [SerializeField] PuzzleSlots Slot;
    [SerializeField] GameObject[] FeedbackBlocks;
    [SerializeField] CameraMove m_CameraMove;

    public Transform CamPos;

    bool Invoked;

    void Awake()
    {
        Invoked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Slot.Satisfied && !Invoked)
        {
            m_CameraMove.Move(CamPos.position, 1f, 0.5f, null);
            Invoked = true;

            for(int i = 0; i < 10; i++)
            {
                FeedbackBlocks[i].SetActive(true);
                //FeedbackBlocks[4].SetActive(true);
            }
            //Destroy(Circle, 3f);
            //PlayerPrefs.DeleteKey("BLOCK ROOT");
            PlayerPrefs.DeleteKey("BLOCK 5");
        }

    }
}
