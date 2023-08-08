using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    public Color startColor = Color.blue;   // Початковий колір
    public Color endColor = Color.red;       // Кінцевий колір
    public float duration = 5.0f;            // Тривалість зміни кольору

    private Image image;
    private float lerpTime;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = startColor;
        lerpTime = duration;
    }

    private void Update()
    {
        lerpTime += Time.deltaTime;

        if (lerpTime > duration)
        {
            // Зміна кольорів
            Color temp = startColor;
            startColor = endColor;
            endColor = temp;
            lerpTime = 0;
        }

        float t = Mathf.PingPong(lerpTime / duration, 1); // Використовуємо PingPong для плавної зміни
        image.color = Color.Lerp(startColor, endColor, t);
    }
}
