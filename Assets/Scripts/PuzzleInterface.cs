using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleInterface : MonoBehaviour
{
    public abstract bool CheckIsCorrect();
    public AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
}
