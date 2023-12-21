using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boat))]
public class BoatInteractable : AbstractInteractable
{
    private Boat _boat;

    private void Start()
    {
        _boat = GetComponent<Boat>();
    }

    public override void Interact(LocalPlayer contextPlayer)
    {
        if (contextPlayer.RowingBoat)
        {
            contextPlayer.gameObject.transform.SetParent(null);
            contextPlayer.RowingBoat = false;
            contextPlayer.CurrentMovementState = LocalPlayer.MovementState.Idle;

            contextPlayer.transform.position = transform.position + Vector3.up;
            return;
        }

        contextPlayer.RowingBoat = true;

        contextPlayer.transform.SetParent(_boat.transform, false);
        contextPlayer.transform.position = _boat.transform.position;
    }

    public override string Title()
    {
        return "[E] Сесть в лодку.";
    }
}
