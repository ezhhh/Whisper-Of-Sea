using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour, Interactable
{
    public abstract void Interact(LocalPlayer contextPlayer);
    public abstract string Title();

    public virtual void ShowBestiariy()
    {

    }
}
