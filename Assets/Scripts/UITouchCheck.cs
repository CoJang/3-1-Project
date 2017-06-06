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

    void Slot1Touched();
    void Slot2Touched();
    void Slot3Touched();
    void Slot4Touched();
    void Slot5Touched();
}

public class UITouchCheck : MonoBehaviour
{

}
