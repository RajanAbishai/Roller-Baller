using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private BallPlayer ball; //getting a reference to the BallPlayer script

    private Vector3 moveDirection;
    private bool jump;

    private float moveHorizontal, moveVertical;

    [SerializeField]
    private GameObject explosionParticle;

    private void Awake()
    {
        ball = GetComponent<BallPlayer>();
    }

    // make sure you get the input in the update function.. always

    private void Update()
    {
        moveHorizontal = Input.GetAxis(TagManager.HORIZONTAL_AXIS);
        moveVertical = Input.GetAxis(TagManager.VERTICAL_AXIS);

        jump = Input.GetKeyDown(KeyCode.Space);

        moveDirection = new Vector3(-moveVertical, 0f, moveHorizontal).normalized; 
        
        // if commented out, moveDirection remains 0
        //. normalized returns the direction of the vector
        
        print(moveDirection);
    }

    private void FixedUpdate()
    {
        ball.Move(moveDirection);
        ball.Jump(jump);
    }

    public void DestroyPlayer()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity); // get the partcile effect to play
        Destroy(gameObject);

    }



}
