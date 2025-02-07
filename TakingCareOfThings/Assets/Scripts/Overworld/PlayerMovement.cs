using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")] 
    public float moveSpeed;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        // move direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f , ForceMode.Force);
    }

}