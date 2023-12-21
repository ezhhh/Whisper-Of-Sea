using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashInteractable : AbstractInteractable
{
    public override void Interact(LocalPlayer contextPlayer)
    {
        Destroy(gameObject);
        contextPlayer.UpdateScore();
    }

    public override string Title()
    {
        return "[E] Убрать мусор.";
    }
}
