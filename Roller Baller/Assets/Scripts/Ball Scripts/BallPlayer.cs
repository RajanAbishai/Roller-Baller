using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 20f;

    [SerializeField]
    private bool useTorque;

    [SerializeField]
    private float maxAngularVelocity = 25f;

    [SerializeField]
    private float jumpForce = 20f;

    [SerializeField]
    private float groundCheckRayLength = 1; // use raycasting to detect if we are on the ground or not

    private Rigidbody myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>(); //is get component efficient or should we use a serialize field? Yes
        myBody.maxAngularVelocity = maxAngularVelocity;
    }

    public void Move(Vector3 moveDirection)
    {
        if (useTorque)
        {
            myBody.AddTorque(new Vector3(moveDirection.z, 0f, -moveDirection.x)* moveForce);

        }

        else
        {
            myBody.AddForce(moveDirection * moveForce);
        }

    }

    public void Jump (bool jump)
    {
        if (Physics.Raycast(transform.position, -Vector3.up, groundCheckRayLength) && jump)  // -Vector3.up is the same as Vector3.down
        {
            myBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            //ForceMode.Impulse is also used in 2d games to add an instant force to a rigid body using its mass.
            //myBody.AddForce.. adds force gradually

        }


    }




}
