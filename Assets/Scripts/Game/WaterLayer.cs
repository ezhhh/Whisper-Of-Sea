using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLayer : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<LocalPlayer>(out var player))
        {
            player.CurrentMovementState = LocalPlayer.MovementState.Swimming;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<LocalPlayer>(out var player))
        {
            player.CurrentMovementState = LocalPlayer.MovementState.Walking;
        }
    }
}
