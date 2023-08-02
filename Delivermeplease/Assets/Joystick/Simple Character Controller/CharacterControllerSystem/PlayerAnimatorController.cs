using UI_InputSystem.Base;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;


    private void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (playerAnimator == null) return;

        // Отримуємо вектор напрямку руху гравця
        Vector3 moveDirection = new Vector3(
            UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.Movement),
            0f,
            UIInputSystem.ME.GetAxisVertical(JoyStickAction.Movement)
        );

        // Встановлюємо параметр isWalking аніматора відповідно до наявності руху
        bool isWalking = moveDirection.magnitude > 0.1f;
        playerAnimator.SetBool("isWalking", isWalking);
    }

}
