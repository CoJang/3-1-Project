using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    SpriteRenderer TouchTheScreen;

    void Awake()
    {
        TouchTheScreen = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        int CountTime = 0;

        while (true)
        {
            if (CountTime % 2 == 0)
                TouchTheScreen.color = new Color32(255, 255, 255, 150);
            else
                TouchTheScreen.color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.75f);

            CountTime++;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeIntoGameScene();
        }
    }

    public void ChangeIntoGameScene()
    {
        SceneManager.LoadScene("MovieScene");
    }
    
}
