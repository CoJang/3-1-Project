using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : BlockColCheck
{
    [SerializeField] Transform PlayerPos;
    [SerializeField] PlayerMove Player;
    [SerializeField] ItemSlot_1 Slot_1;

    public bool IsPickUped;
    public bool IsActionable = true;

    // Use this for initialization
    void Start()
    {
        IsPickUped = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!IsActionable)
        {
            return;
        }

        if (Player.isItemHold && IsPickUped && !Slot_1.IsEquiped && IsActionable)
        {
            transform.position = new Vector3(PlayerPos.position.x, PlayerPos.position.y + 1.25f, PlayerPos.position.z);
        }
    }

    protected override void OnBlockCollition()
    {

        if (!Player.isItemHold && !Slot_1.IsEquiped && IsActionable) // if Player is not Holding a Block
        {
            IsPickUped = true;
        }

        if(Slot_1.IsEquiped)
        {
            Player.isItemHold = false;
        }

    }

    protected override void OnItemEquiption()
    {
        transform.position = Slot_1.transform.position;
    }

    IEnumerator DelayedInteraction()
    {
        yield return new WaitForSeconds(1.0f);
        IsActionable = true;
    }

    public void DisableBlock()
    {
        IsActionable = false;
    }
}
