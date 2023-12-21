using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public LocalPlayer Player;
    public LayerMask WaterLayer;
    public int score = 0;
    public TMP_Text text;

    private void Update()
    {
        text.text = score.ToString();
    }

    private void Start()
    {
        Instance = this;

        Player = GameObject.FindFirstObjectByType<LocalPlayer>();
    }

}
