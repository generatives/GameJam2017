using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : NetworkBehaviour
{

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public float maxAirVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    private CharacterController controller;

    private float distToGround;
    
    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        //body.freezeRotation = true;
        //body.useGravity = false;

        var collider = gameObject.GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
    }

    //void FixedUpdate()
    //{
    //    if (!isLocalPlayer)
    //        return;

    //    grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

    //    var maxChange = grounded ? maxVelocityChange : maxAirVelocityChange;
    //    // Calculate how fast we should be moving
    //    Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    targetVelocity = transform.TransformDirection(targetVelocity);
    //    targetVelocity *= speed;

    //    // Apply a force that attempts to reach our target velocity
    //    Vector3 velocity = body.velocity;
    //    Vector3 velocityChange = (targetVelocity - velocity);
    //    velocityChange.x = Mathf.Clamp(velocityChange.x, -maxChange, maxChange);
    //    velocityChange.z = Mathf.Clamp(velocityChange.z, -maxChange, maxChange);
    //    velocityChange.y = 0;
    //    body.AddForce(velocityChange, ForceMode.VelocityChange);

    //    // Jump
    //    if (grounded && canJump && Input.GetButton("Jump"))
    //    {
    //        body.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
    //    }

    //    // We apply gravity manually for more tuning control
    //    body.AddForce(new Vector3(0, -gravity * body.mass, 0));

    //    grounded = false;
    //}

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();
        direction = transform.TransformDirection(direction);
        float curSpeed = 10f;
        controller.Move(direction * curSpeed * Time.deltaTime);
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    public void UpdateStats(PlayerStats stats)
    {
        speed = stats.moveSpeed;
        jumpHeight = stats.jumpHeight;
    }

}