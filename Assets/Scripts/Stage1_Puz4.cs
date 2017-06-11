﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Puz4 : PuzzleInterface
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

        CheckIsCorrect();
    }

    public override bool CheckIsCorrect()
    {
        if (Slot.Satisfied && !Invoked)
        {
            m_CameraMove.Move(CamPos.position, 1f, 0.5f, null);
            Invoked = true;

            for (int i = 0; i < 10; i++)
            {
                FeedbackBlocks[i].SetActive(true);
            }
            PlayerPrefs.DeleteKey("BLOCK 5");
            return true;
        }
        else
            return false;
    }
}
