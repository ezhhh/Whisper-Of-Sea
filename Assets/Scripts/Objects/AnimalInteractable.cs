using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteractable : AbstractInteractable
{

    private void Start()
    {
     
    }

    public override void Interact(LocalPlayer contextPlayer)
    {
        transform.position = contextPlayer.transform.forward * 2;
    }

    public override string Title()
    {
        return "[E] Что-то сделать.";
    }
}
