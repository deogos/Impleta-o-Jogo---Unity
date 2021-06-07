using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8f;
    public float jumpForce = 6f;

    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    Vector3 velocity;
    Vector3 inputDirection;

    new BoxCollider collider;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        velocity = inputDirection * moveSpeed;

        float inputMagnitude = inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed);
    }

    void FixedUpdate()
    {
        if (inputDirection.x == 0 && inputDirection.z == 0){}
        else
        {
            rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        }
        rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);

        PlayerJump();
    }

    void PlayerJump()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, 
            collider.bounds.min.y, collider.bounds.center.z), collider.bounds.min.y * 0.9f);

    }

}
