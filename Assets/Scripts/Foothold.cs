using UnityEngine;
using System.Collections;

public class Foothold : MonoBehaviour {

    ///////////////////////////////
    //
    // Private Variable
    //
    ///////////////////////////////

    [SerializeField] Vector3    m_UpPosition;
    [SerializeField] Vector3    m_DownPosition;
    [SerializeField] float      m_MoveTime;

    AudioSource m_MoveSound;
    Transform   m_Transform;
    bool        m_IsUpside;


    ///////////////////////////////
    //
    // Property
    //
    ///////////////////////////////

    public bool isUpside { get { return m_IsUpside; } }

    ///////////////////////////////
    //
    // Function
    //
    ///////////////////////////////

    void Awake()
    {
        m_Transform = transform;
        m_MoveSound = GetComponent<AudioSource>();

        if (m_Transform.position == m_UpPosition)
            m_IsUpside = true;
        else
            m_IsUpside = false;
    }

    public void MoveUp(float delay)
    {
        m_IsUpside = true;
        StartCoroutine(MoveToUpside(delay));
    }

    public void MoveDown(float delay)
    {
        m_IsUpside = false;
        StartCoroutine(MoveToDownside(delay));
    }

    IEnumerator MoveToUpside(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_MoveSound.Play();

        Vector3 startPos = transform.position;

        for(float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / m_MoveTime)
        {
            m_Transform.position = Vector3.Lerp(startPos, m_UpPosition, rate);
            yield return null;
        }
        m_Transform.position = m_UpPosition;
    }

    IEnumerator MoveToDownside(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_MoveSound.Play();

        Vector3 startPos = transform.position;

        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / m_MoveTime)
        {
            m_Transform.position = Vector3.Lerp(startPos, m_DownPosition, rate);
            yield return null;
        }
        m_Transform.position = m_DownPosition;
    }

}
