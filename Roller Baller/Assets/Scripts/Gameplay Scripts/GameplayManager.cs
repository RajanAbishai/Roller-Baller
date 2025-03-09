using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField]
    private Text coinTxt, timerTxt;
    private int coinCount;

    [SerializeField]
    private float timerThreshold = 150f;

    private float timerCount;
    private StringBuilder coinString = new StringBuilder();

    private StringBuilder timerString = new StringBuilder(); //to use a string builder we have to declare it. More efficient when adding strings instead of concatenating

    //string builder is an array for storing strings

    private bool gameOver;

    [SerializeField]
    private GameObject gameOverPanel;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Destroy the copy (current copy) holding the copy of the gameplay manager

        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        timerCount = Time.time + 1f; //advance time by 1 before we start counting the time

    }

    private void Update()
    {
        if (gameOver)
        {
            return;
        }

        CountTimer();
        if (timerThreshold == 0f || coinCount==0) //if time has run out
        {
            GameOver();
        }


    }

    public void SetCoinCount(int coinValue) // we can use the coinValue parameter to add or subtract
    {
        coinCount += coinValue;
        coinString.Length = 0; // explained in line 68
        coinString.Append("Coins: ");
        coinString.Append(coinCount.ToString());
        coinTxt.text = coinString.ToString(); //creates only 1 string

        // this is much more efficient than what is below.. what is below creates 2 strings
        // counTxt.text= "Coin: " + coinCount.ToString(); 

    }

    void CountTimer()
    {
        if (Time.time > timerCount)
        {
            timerCount = Time.time + 1;
            timerThreshold--;

            timerString.Length = 0; // if you omit this, .. assume that time is "Time: 149" the next time you append the time(next line), "Time: 149Time: 148"
            timerString.Append("Time :");
            timerString.Append(timerThreshold.ToString());

            timerTxt.text = timerString.ToString();
        }



    }

    public void GameOver()
    {
        gameOver = true; // will control update function with it

        GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<BallController>().DestroyPlayer();
        Invoke("ShowGameOverPanel", 1f);
    }


    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);


    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0); //index of the level I wanna load 
    }

}
