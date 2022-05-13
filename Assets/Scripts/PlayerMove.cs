using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector] public Vector2 stickDirection;
    Vector3 moveDirectionLat;
    Vector3 moveDirection;
    Vector3 startGravity;
    Vector3 updateGravity;
    Vector3 lastVelocity;

    CharacterController controller;

    public float playerSpeed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startGravity = Physics.gravity;

    }

    public void OnMovePlayer(InputAction.CallbackContext obj)
    {
        stickDirection = obj.ReadValue<Vector2>();
    }
    private void Update()
    {
        updateGravity = GravityVector();
    }
    private void FixedUpdate()
    {
        moveDirectionLat = new Vector3(stickDirection.x, 0f, stickDirection.y) * playerSpeed;
        moveDirection = moveDirectionLat + updateGravity;
        lastVelocity = moveDirection; 
        controller.Move(moveDirection * Time.deltaTime);
    }
    private Vector3 GravityVector()
    {
        if(!controller.isGrounded)
        {
            var gravVectorAir = lastVelocity +startGravity * Time.deltaTime*2;
            gravVectorAir.x = 0;
            gravVectorAir.z = 0;
            return gravVectorAir;
        }
        else
        {
            var gravVector = lastVelocity + startGravity * Time.deltaTime * 0.2f;
            gravVector.x = 0;
            gravVector.z = 0;
            return gravVector;
        }

    }
}
