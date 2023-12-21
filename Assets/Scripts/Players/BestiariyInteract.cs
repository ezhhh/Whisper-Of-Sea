using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class BestiariyInteract : AbstractInteractable
{
    public GameObject bestiaryPanel;
    public TextMeshProUGUI bestiaryText;

    [SerializeField] private GameObject[] trash;

    public override void ShowBestiariy()
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
            Debug.Log("error");
        }

        bestiaryPanel.SetActive(!bestiaryPanel.activeSelf);
    }

    public override void Interact(LocalPlayer contextPlayer)
    {
        foreach (var trashItem in trash)
        {
            if (!trashItem.gameObject.activeSelf)
            {
                continue;
            }

            trashItem.gameObject.SetActive(false);
            contextPlayer.UpdateScore();
            break;
        }
    }

    public override string Title()
    {
        return "[I] Открыть бестиарий. [E] Снять мусор.";
    }
}

