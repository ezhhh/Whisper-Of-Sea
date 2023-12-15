using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactionDistance = 5f;

    public LocalPlayer player;
    public GameSettings gameSettings;

    private void Update()
    {
        if (GameSettings.Instance.IsDown(GameSettings.Instance.InteractKey))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionDistance))
            {
                AbstractInteractable interactable = hit.collider.gameObject.GetComponent<AbstractInteractable>();
                if (interactable != null)
                {
                    Debug.Log("You interacted");
                    interactable.Interact(player);
                }
            }
        }
    }
}
