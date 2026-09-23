using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 1.1f;
    public LayerMask groundLayer;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    public Transform cam;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }

    void Update()
    {
        CheckGround();

        if (SimpleInput.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void FixedUpdate()
    {
        float h = SimpleInput.GetAxis("Horizontal");
        float v = SimpleInput.GetAxis("Vertical");

        Vector3 camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = Vector3.Scale(cam.right, new Vector3(1, 0, 1)).normalized;

        Vector3 moveDir = (camForward * v + camRight * h).normalized;

        // Movimiento
        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        // Rotación
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}