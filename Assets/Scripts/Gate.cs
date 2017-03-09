using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    ///////////////////////////////
    //
    // Private Variable
    //
    ///////////////////////////////

    [SerializeField] Vector3    m_OpenPosition;
    [SerializeField] float      m_OpenTime;

    AudioSource m_OpenSound;
    Transform   m_Transform;
    bool        m_IsOpen;


    ///////////////////////////////
    //
    // Property
    //
    ///////////////////////////////

    public bool isOpen { get { return m_IsOpen; } }

    ///////////////////////////////
    //
    // Function
    //
    ///////////////////////////////

    void Awake()
    {
        m_Transform = transform;
        m_OpenSound = GetComponent<AudioSource>();
    }

    public void Open(float delay)
    {
        m_IsOpen = true;
        StartCoroutine(UpdateOpen(delay));
    }

    IEnumerator UpdateOpen(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_OpenSound.Play();

        Vector3 startPos = transform.position;
        for(float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / m_OpenTime)
        {
            m_Transform.position = Vector3.Lerp(startPos, m_OpenPosition, rate);
            yield return null;
        }
        m_Transform.position = m_OpenPosition;
    }

}
