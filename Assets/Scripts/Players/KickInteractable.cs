using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickInteractable : AbstractInteractable
{

    public override void Interact(LocalPlayer contextPlayer)
    {
        this.transform.position = contextPlayer.transform.position;
    }

    public override string Title()
    {
        return "[E] Позвать к себе.";
    }
}
