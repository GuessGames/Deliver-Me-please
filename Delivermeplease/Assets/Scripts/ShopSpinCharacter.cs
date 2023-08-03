using UnityEngine;

public class ShopSpinCharacter : MonoBehaviour
{
    public float rotationSpeed = 30f; // Скорость вращения объекта (градусов в секунду)

    private Quaternion initialRotation; // Начальный поворот объекта

    private void Start()
    {
        // Получаем начальный поворот объекта
        initialRotation = transform.rotation;

        // Поворачиваем объект на 180 градусов по оси Y
        transform.Rotate(Vector3.up, 180f);
    }

    private void FixedUpdate()
    {
        // Вращаем объект по оси Y со скоростью rotationSpeed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
