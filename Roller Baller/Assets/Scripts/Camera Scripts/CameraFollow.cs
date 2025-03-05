using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;

    [SerializeField]
    private float distance = 10f; //distance between player and camera

    [SerializeField]
    private float cameraHeight = 5f;

    [SerializeField]
    private float heightDamping = 2f;


    private float wantedHeight, currentHeight;

    private Quaternion currentRotation;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate() //late update is caleld last. If you have code to make a game object follow another, put it in late update
    {
        /*if (!playerTarget) { 
        
            return; //not doing these calculations because we will get null reference exception. If player is dead, we will get a null reference exception
        }*/

        if (playerTarget) { 

        wantedHeight = playerTarget.position.y + cameraHeight;

        currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime); // it moves from currentHeight to wantedHeight.. gradually. What lerp does.

        currentRotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);

        transform.position = playerTarget.position; //this makes the camera be at the same position where the player is

        transform.position -= currentRotation * Vector3.forward * distance;
        //It is going to move the camera away from the player target by subtracting from it backwards.. it is going to go backwards

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(playerTarget);
        }
    }





}
