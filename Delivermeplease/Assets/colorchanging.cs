using UnityEngine;

public class colorchanging : MonoBehaviour
{
    public float changeInterval = 5.0f;   // Інтервал зміни кольору

    private Camera camera;
    private float lastChangeTime;
    private Color targetColor;

    private void Start()
    {
        camera = GetComponent<Camera>();
        lastChangeTime = Time.time;
        ChangeBackgroundColor();
    }

    private void Update()
    {
        if (Time.time - lastChangeTime > changeInterval)
        {
            ChangeBackgroundColor();
            lastChangeTime = Time.time;
        }

        camera.backgroundColor = Color.Lerp(camera.backgroundColor, targetColor, Time.deltaTime);
    }

    private void ChangeBackgroundColor()
    {
        targetColor = new Color(Random.value, Random.value, Random.value);
    }
}
