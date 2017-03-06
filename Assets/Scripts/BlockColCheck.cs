using UnityEngine;
using System.Collections;

public abstract class BlockColCheck : MonoBehaviour {

    protected SpriteRenderer m_SR;
    protected abstract void OnBlockCollition();

    void Awake()
    {
        m_SR.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Touched");
            OnBlockCollition();
        }

    }

}
