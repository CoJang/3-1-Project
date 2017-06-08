using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotContrl : MonoBehaviour
{
    Animator Ani;
    [SerializeField] Image[] UI_Slots;
	// Use this for initialization
	void Start ()
    {
        Ani = GetComponent<Animator>();
    }
	
    public void ShotBlocks()
    {
        Ani.SetBool("Shot", true);
        Ani.SetBool("Shake", false);
        Ani.SetBool("Collect", false);
    }

    public void ShakeBlocks()
    {
        Ani.SetBool("Shake", true);
        Ani.SetBool("Shot", false);
        Ani.SetBool("Collect", false);
    }

    public void CollectBlocks()
    {
        Ani.SetBool("Shake", false);
        Ani.SetBool("Collect", true);
        Ani.SetBool("Shot", false);
    }

    public void DisableSlots()
    {
        for(int i = 0; i < 5; i++)
        {
            UI_Slots[i].enabled = false;
        }
    }
}
