using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public LocalPlayer Player;
    public LayerMask WaterLayer;

    private void Start()
    {
        Instance = this;

        Player = GameObject.FindFirstObjectByType<LocalPlayer>();
    }

}
