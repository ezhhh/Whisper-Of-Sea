using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteractable : AbstractInteractable
{
   

    public override void Interact(LocalPlayer contextPlayer)
    {
      
    }

    public override string Title()
    {
        return "[E] Снять мусор. [I] Открыть бестиарий.";
    }
}
