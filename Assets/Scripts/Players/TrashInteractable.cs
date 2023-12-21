using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteractable : AbstractInteractable
{
    public override void Interact(LocalPlayer contextPlayer)
    {
        Destroy(gameObject);
    }

    public override string Title()
    {
        return "[E] Убрать мусор.";
    }
}
