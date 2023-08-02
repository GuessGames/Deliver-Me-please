using UI_InputSystem.Base;
using UnityEngine;

public class RotatePlayerMesh : MonoBehaviour
{
    [SerializeField]
    private Transform playerMeshTransform;
    
    private void Update()
    {
        RotateMeshTowardsJoystick();
    }

    private void RotateMeshTowardsJoystick()
    {
        if (!playerMeshTransform) return;

        // Отримуємо напрямок руху зі стіка
        Vector3 moveDirection = new Vector3(
            UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.Movement),
            0f,
            UIInputSystem.ME.GetAxisVertical(JoyStickAction.Movement)
        );

        // Перевіряємо, чи є напрямок руху
        if (moveDirection.magnitude > 0.1f)
        {
            // Повертаємо меш гравця у напрямку руху
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            playerMeshTransform.rotation = Quaternion.Slerp(playerMeshTransform.rotation, targetRotation, 0.15f);
        }
    }
}
