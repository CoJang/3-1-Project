using UnityEngine;
using System.Collections;

public class KeyInpuManager : MonoBehaviour {

    public RectTransform Left_Arrow;
    public RectTransform Right_Arrow;
    public RectTransform Jump_BT;

    public IinputListener Listerner;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
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

            if(RectTransformUtility.RectangleContainsScreenPoint(Jump_BT, Input.mousePosition, Camera.main))
            {
                Listerner.Jump();
            }
        }

    }
}
