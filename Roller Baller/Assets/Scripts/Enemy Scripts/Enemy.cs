using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float minMoveSpeed=0.5f, maxMoveSpeed = 2f;

    private float moveSpeed;

    [SerializeField]
    private float minDistance = 1f; //checking the distance between the player and the enemy.

    private float distance;

    private Transform playerTarget;


    private void Awake()
    {
        //playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform; // Done with enemy spawner

    }

    private void Start()
    {
        setMoveSpeed();

    }

    private void Update()
    {
        if (!playerTarget) //if we don't have a reference to the player target, we return.. and don't execute the code further below
        
            return;

        transform.LookAt(playerTarget); //this is used to rotate the cube towards the player

        //distance = Vector3.Distance(transform.position, playerTarget.position);



        distance = (transform.position - playerTarget.position).sqrMagnitude;

        /* Vector3.Distance is not that optimized because it is using the square root of distance. We don't need to use the square root.
        
        The distance function essentially subtracts from one position and it is getting the magnitude. 
        Getting the magnitude involves a square root in the operation
         
         */



        if (distance > minDistance)
        {
            transform.position += transform.forward * moveSpeed *Time.deltaTime; 
            /*uses the forward orientation.. and since we are using LookAt.. this is going to make the cube look at the target.. which is essentially going to rotate
            the cube towards the player.. and multiply with move speed and Time.deltaTime*/

        }

    }



    void setMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    public void setTarget(Transform target)
    {
        playerTarget = target;

    }

   


} // class


