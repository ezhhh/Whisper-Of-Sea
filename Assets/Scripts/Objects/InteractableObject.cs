using UnityEngine;

public class InteractableObject : AbstractInteractable
{
    [SerializeField] private string _objectName;

    public override void Interact(LocalPlayer contextPlayer)
    {
        Debug.Log("You interacted " + _objectName);
    }

    public override string Title()
    {
        return _objectName;
    }

    private void OnTriggerEnter(Collider other)
    {
        LocalPlayer player = other.GetComponent<LocalPlayer>();
        if (player != null)
        {
            Debug.Log("You can interact with " + _objectName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LocalPlayer player = other.GetComponent<LocalPlayer>();
        if (player != null)
        {
            Debug.Log("You can no longer interact with " + _objectName);
        }
    }
}
