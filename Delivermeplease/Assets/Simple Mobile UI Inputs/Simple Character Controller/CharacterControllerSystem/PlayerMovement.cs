using UI_InputSystem.Base;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform, groundChecker;

    [SerializeField]
    private CharacterController controllerPlayer;

    [SerializeField]
    [Range(2f, 10f)]
    private float playerHorizontalSpeed = 8;

    [SerializeField]
    private bool useGravity = true;

    [SerializeField]
    [Range(-50f, -9.8f)]
    private float gravityValue = -10;

    [SerializeField]
    [Range(0.1f, 1f)]
    private float groundDistance = 0.5f;

    [SerializeField]
    private LayerMask groundMask;


    private Vector3 gravityVelocity;
    
    public bool Grounded => Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

    
    
    private void FixedUpdate()
    {
        MovePlayer();
        CalculateGravity();
    }
    
    private void MovePlayer()
    {
        if (!playerTransform) return;
        
        controllerPlayer.Move(PlayerMovementDirection());
    }

    private void CalculateGravity() 
    {
        if (!useGravity) return;
        if (!groundChecker) return;

        ResetGravityIfGrounded();
        ApplyGravity();
    }


    private void ApplyGravity()
    {
        gravityVelocity.y += gravityValue * Time.deltaTime;
        controllerPlayer.Move(gravityVelocity * Time.deltaTime);
    }

    private void ResetGravityIfGrounded()
    {
        if (Grounded && gravityVelocity.y < 0)
            gravityVelocity.y = -1.5f;
    }
    
    private Vector3 PlayerMovementDirection()
    {
        var baseDirection = playerTransform.right * UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.Movement) +
                            playerTransform.forward * UIInputSystem.ME.GetAxisVertical(JoyStickAction.Movement);

        baseDirection *= playerHorizontalSpeed * Time.deltaTime;
        return baseDirection;
    }

    
}