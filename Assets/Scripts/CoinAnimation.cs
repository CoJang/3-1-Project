using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : BlockColCheck {

    Animator Ani;
    Transform m_DstPos;
    AudioSource m_CoinSound;

    new void Awake ()
    {
        m_DstPos = transform;
        //m_DstPos.position = new Vector3(transform.position.x, transform.position.y +3, transform.position.z);
        Ani = GetComponent<Animator>();
        m_CoinSound = GetComponent<AudioSource>();
    }

    protected override void OnBlockCollition()
    {
        Ani.SetTrigger("Touch");
        StartCoroutine(UpdateMove(new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), 1f, 0.5f, null));
        m_CoinSound.Play();
    }

    IEnumerator UpdateMove(Vector3 dstPosition, float moveTime, float delayTime, Action callback)
    {
        Vector3 srcPosition = transform.position;
        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / moveTime)
        {
            transform.position = Vector3.Lerp(srcPosition, dstPosition, rate);
            yield return null;
        }
        yield return new WaitForSeconds(delayTime);
        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / moveTime)
        {
            transform.position = Vector3.Lerp(dstPosition, srcPosition, rate);
            yield return null;
        }
        if (callback != null)
            callback();
    }
}
