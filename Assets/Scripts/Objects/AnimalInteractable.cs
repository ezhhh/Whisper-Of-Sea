using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteractable : AbstractInteractable
{
    [SerializeField] private GameObject[] trash;

    public override void Interact(LocalPlayer contextPlayer)
    {
        foreach (var trashItem in trash)
        {
            if (!trashItem.gameObject.activeSelf)
            {
                continue;
            }

            trashItem.gameObject.SetActive(false);
        }
    }

    public override string Title()
    {
        return "[E] Снять мусор. [I] Открыть бестиарий.";
    }
}
