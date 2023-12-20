using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    private TextMeshProUGUI splashText;
    public List<string> textOptions = new List<string>();

    void Start()
    {
        splashText = GetComponent<TextMeshProUGUI>();
        if (splashText != null)
        {
            ChangeText();
        }
        else
        {
            Debug.LogError("No TextMeshProUGUI component found on this GameObject.");
        }
    }

    public void ChangeText()
    {
        if (textOptions.Count > 0)
        {
            int index = Random.Range(0, textOptions.Count);
            splashText.text = textOptions[index];
        }
        else
        {
            Debug.LogError("No text options provided.");
        }
    }
}
