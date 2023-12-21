using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashInteractable : AbstractInteractable
{
    public static int score = 0;
    public TMP_Text tmpro;
    public override void Interact(LocalPlayer contextPlayer)
    {
        score++;
        Debug.Log(score);
        Destroy(gameObject);
    }

    private void Update()
    {
        tmpro.text = score.ToString();
    }

    public override string Title()
    {
        return "[E] Убрать мусор.";
    }
}
