using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)  //Enemy game objects use oncollision
    {
        if (collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            //collision.gameObject.GetComponent<BallController>().DestroyPlayer();
            //commenting out as the destroy player code is already there in the below function
            GameplayManager.instance.GameOver();

        }

    }




    private void OnTriggerEnter(Collider other) //death zone uses ontrigger
    {
        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            //other.gameObject.GetComponent<BallController>().DestroyPlayer();
            //commenting out as the destroy player code is already there in the below function
            GameplayManager.instance.GameOver();
        }

    }
    



}
