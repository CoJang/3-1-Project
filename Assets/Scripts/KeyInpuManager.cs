using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class KeyInpuManager : MonoBehaviour {

    public RectTransform Left_Arrow;
    public RectTransform Right_Arrow;
    public RectTransform Jump_BT;

    public IinputListener Listerner;

    private Touch tempTouchs;
    private Vector3 touchPos;

    private bool jumpcheck; 

	// Use this for initialization
	//void Start ()
    //{
   // }
	
	// Update is called once per frame

	void Update ()
    {

        if(Application.platform == RuntimePlatform.Android) // 안드로이드 이면 아래 구문 실행 
        {
            if (Input.touchCount > 0)
            {
                for(int i = 0; i < Input.touchCount; i++)
                {
                    tempTouchs = Input.GetTouch(i);

                    if(tempTouchs.phase == TouchPhase.Began)
                    {
                        if (RectTransformUtility.RectangleContainsScreenPoint(Left_Arrow, tempTouchs.position, Camera.main))
                        {
                            Listerner.Lmove();
                        }

                        if (RectTransformUtility.RectangleContainsScreenPoint(Right_Arrow, tempTouchs.position, Camera.main))
                        {
                            Listerner.Rmove();
                        }

                        if (RectTransformUtility.RectangleContainsScreenPoint(Jump_BT, tempTouchs.position, Camera.main))
                        {
                            //jumpcheck = true;
                            //Listerner.CheckTouchedTime();
                        }

                        break;
                    }

                    if(tempTouchs.phase == TouchPhase.Moved || tempTouchs.phase == TouchPhase.Stationary)
                    {
                        if (RectTransformUtility.RectangleContainsScreenPoint(Left_Arrow, tempTouchs.position, Camera.main))
                        {
                            Listerner.Lmove();
                        }

                        if (RectTransformUtility.RectangleContainsScreenPoint(Right_Arrow, tempTouchs.position, Camera.main))
                        {
                            Listerner.Rmove();
                        }

                        if (RectTransformUtility.RectangleContainsScreenPoint(Jump_BT, tempTouchs.position, Camera.main))
                        {
                            jumpcheck = true;
                            Listerner.CheckTouchedTime();
                        }
                    }

                    if(tempTouchs.phase == TouchPhase.Ended)
                    {
                        if(jumpcheck)
                        {
                            jumpcheck = false;
                            Listerner.Jump();
                        }
                    }
                }
            }
        }

        else // 안드로이드가 아닌 경우 아래구문 실행
        {
            if (Input.GetMouseButton(0))
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(Left_Arrow, Input.mousePosition, Camera.main))
                {
                    Listerner.Lmove();
                }

                if (RectTransformUtility.RectangleContainsScreenPoint(Right_Arrow, Input.mousePosition, Camera.main))
                {
                    Listerner.Rmove();
                }

                if (RectTransformUtility.RectangleContainsScreenPoint(Jump_BT, Input.mousePosition, Camera.main))
                {
                    jumpcheck = true;
                    Listerner.CheckTouchedTime();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                if(jumpcheck)
                {
                    jumpcheck = false;
                    Listerner.Jump();
                }
            }
        }
    }
}
