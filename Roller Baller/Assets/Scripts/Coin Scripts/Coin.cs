using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagManager.PLAYER_TAG)
        {
            //inform player that coin has been collected
            GameplayManager.instance.SetCoinCount(-1); //collected a coin. So, we pass -1. 

            // play sound
            AudioManager.instance.PlayCoinSound();

            gameObject.SetActive(false);


        }
    }


    private void Start()
    {
        //inform game manager that the coin has been created

        GameplayManager.instance.SetCoinCount(1);
    }

}
