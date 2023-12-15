using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InteractableTitle : MonoBehaviour
{
    private Text _titleText;

    private void Start() => _titleText = GetComponent<Text>();

    private void Update()
    {
        _titleText.text = TitleText();
    }

    private string TitleText()
    {
        LocalPlayer player = GameManager.Instance.Player;

        return (player == null || player.PointedObject == null) ? "" : player.PointedObject.Title();
    }
}
