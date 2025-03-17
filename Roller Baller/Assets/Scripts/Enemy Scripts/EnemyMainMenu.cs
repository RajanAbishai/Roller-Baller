using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMainMenu : MonoBehaviour
{


    [SerializeField]
    private float minMoveSpeed = 0.5f, maxMoveSpeed = 2f;

    private float moveSpeed;

    [SerializeField]
    private float minDistance = 0.5f; // minimum distance enemy can move before we can change the direction

    private float distance;

    [SerializeField]
    private Transform[] movingPoints;

    private Transform target;

    private void Start()
    {
        target = movingPoints[Random.Range(0, movingPoints.Length)];
        SetMoveSpeed();

    }

    void SetMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

    }

    private void Update()
    {
        transform.LookAt(target);
        
        distance = Vector3.Distance(transform.position,target.position);

        //Since square root is faster

        //distance = (transform.position - target.position).sqrMagnitude;

        /* since the above line is squared, the below line has to be squared.
        // if (distance > minDistance*minDistance)
        */

        if (distance > minDistance)

        
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        else
            target = movingPoints[Random.Range(0, movingPoints.Length)];
    }



}
