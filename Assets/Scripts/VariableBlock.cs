using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableBlock : BlockColCheck
{
    [SerializeField] Sprite[] m_Sprite; // = new Sprite[10];
    [SerializeField] GameObject Col_effect;
    [SerializeField] GameObject Add_effect;

    public int SprNum;
    public int EventCondition;
    public bool Satisfied;
    public int MaxSprNum;

    private AudioSource ColSound;

    void Start()
    {
        ColSound = GetComponent<AudioSource>();

        if (SprNum == EventCondition)
        {
            Satisfied = true;
        }
        else
        {
            Satisfied = false;
        }
    }

    protected override void OnBlockCollition()
    {
        Instantiate(Col_effect, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
        Instantiate(Add_effect, new Vector3(transform.position.x, transform.position.y + 0.47f, transform.position.z), Quaternion.identity);
        ColSound.Play();
        SprNum = (++SprNum) % MaxSprNum;
        m_SR.sprite = m_Sprite[SprNum];

        if (SprNum == EventCondition)
        {
            Satisfied = true;
        }
        else
        {
            Satisfied = false;
        }
    }
}
