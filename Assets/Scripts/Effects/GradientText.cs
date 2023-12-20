using UnityEngine;
using TMPro;

public class GradientText : MonoBehaviour
{
    public Color topColor = Color.red;
    public Color bottomColor = Color.blue;
    public float speed = 1.0f;
    public float displacement = 0.1f;

    private TMP_Text textMesh;
    private float time;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        float t = Mathf.PingPong(time, 1.0f);
        ApplyGradient(t);
    }

    void ApplyGradient(float t)
    {
        Color colorTop = Color.Lerp(bottomColor, topColor, t);
        Color colorBottom = Color.Lerp(topColor, bottomColor, t);

        var gradientPreset = ScriptableObject.CreateInstance<TMP_ColorGradient>();
        gradientPreset.topLeft = colorTop;
        gradientPreset.topRight = colorTop;
        gradientPreset.bottomLeft = colorBottom;
        gradientPreset.bottomRight = colorBottom;

        textMesh.colorGradientPreset = gradientPreset;
        textMesh.colorGradientPreset.bottomLeft = Color.Lerp(bottomColor, topColor, t + displacement);
        textMesh.colorGradientPreset.bottomRight = Color.Lerp(bottomColor, topColor, t + displacement);
    }
}
