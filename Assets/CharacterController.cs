using UnityEngine;

public class CharacterController : MonoBehaviour
{
[Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float boostMultiplier = 2f; 
    [SerializeField] private KeyCode boostKey = KeyCode.LeftShift;


    [Header("Rotation Settings")]
    [SerializeField] private bool rotateTowardsMouse = true;

    private Vector2 inputDirection; 

    void Update()
    {
        HandleMovement();

        if (rotateTowardsMouse)
        {
            RotateTowardsMouse();
        }
    }

    private void HandleMovement()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");  

        // Combine input into a direction vector
        inputDirection = new Vector2(moveX, moveY).normalized;
        float currentSpeed = Input.GetKey(boostKey) ? moveSpeed * boostMultiplier : moveSpeed;

        // Move the sprite
        transform.Translate(inputDirection * currentSpeed * Time.deltaTime, Space.World);
    }

    private void RotateTowardsMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the sprite to the mouse
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;

        // Calculate the angle (in degrees) between the sprite's forward direction and the mouse direction
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // Set the sprite's rotation to face the mouse
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
