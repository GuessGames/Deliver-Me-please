using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 10, -10); // Змінна для визначення відстані камери від гравця

    [SerializeField]
    private float followSpeed = 5f; // Швидкість переміщення камери


    private void FixedUpdate()
    {
        if (!playerTransform) return;

        // Обчислюємо нове положення камери
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
