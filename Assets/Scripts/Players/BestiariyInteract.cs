using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class BestiariyInteract : AbstractInteractable
{
    public GameObject bestiaryPanel;
    public TextMeshProUGUI bestiaryText;

    public override void Interact(LocalPlayer contextPlayer)
    {
        string animalName = gameObject.tag;
        string path = Path.Combine(Application.dataPath, "BestiaryTXT", animalName + ".txt");

        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            bestiaryText.text = content;
        }
        else
        {
            Debug.Log("Файл не найден");
        }

        bestiaryPanel.SetActive(!bestiaryPanel.activeSelf);
    }

    public override string Title()
    {
        return "[I] Посмотреть бестиарий.";
    }
}

