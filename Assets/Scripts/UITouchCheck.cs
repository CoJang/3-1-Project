using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IinputListener
{
    void Jump();
    //IEnumerator Jump();
    //IEnumerator CheckTouchedTime();
    void CheckTouchedTime();
    void Lmove();
    void Rmove();
    void ShowInven();
}

public class UITouchCheck : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    { 

    }

}
