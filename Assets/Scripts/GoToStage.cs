using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStage : MonoBehaviour
{
    public RectTransform Stage1;

    private Touch tempTouchs;
    private Vector3 touchPos;

    void Update ()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs = Input.GetTouch(i);

                if (tempTouchs.phase == TouchPhase.Began)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(Stage1, tempTouchs.position, Camera.main))
                    {
                        //SceneManager.LoadScene("MovieScene");
                    }
                }
            }
        }

        else if (Input.GetMouseButton(0))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(Stage1, Input.mousePosition, Camera.main))
            {
                //SceneManager.LoadScene("MovieScene");
            }
        }
    }

    public void GotoNext()
    {
        SceneManager.LoadScene("MovieScene");
    }
}
