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
        //if (instance != null)
        //{
        //    Destroy(gameObject); // Destroy the copy (current copy) holding the copy of the gameplay manager

        //}

        //else
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        
        //modified to fix the issue where coin count isn't updated when the scene is restarted. Under the GameplayManger, Coin Txt, Timer Txt and game over panel elements are missing when restarted
        instance = this;

        //coinTxt = GameObject.Find("Coin Count").GetComponent<Text>();
        //timerTxt = GameObject.Find("Timer Count").GetComponent<Text>();
        //gameOverPanel = GameObject.Find("GameOver Panel");
        //gameOverPanel.SetActive(false);

        //Find functions are not optimized but since this is the initialization of the level and you don't have several lines using it, it's fine


        timerCount = Time.time + 1f; //advance time by 1 before we start counting the time

        //Below code is added because the first second, it shows "Time: 0".

        timerTxt.text = "Time :" + timerThreshold; // not efficient but doing it in the beginning of the level. So, it won't have a huge impact

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
        
      //  if (coinTxt != null) { 

        coinCount += coinValue;
        coinString.Length = 0; // explained in line 68
        coinString.Append("Coins: ");
        coinString.Append(coinCount.ToString());
        coinTxt.text = coinString.ToString(); //creates only 1 string

        // this is much more efficient than what is below.. what is below creates 2 strings
        // counTxt.text= "Coin: " + coinCount.ToString(); 
        //        }
        //      else { Debug.Log("CoinTxt is destroyed or not assigned"); }

        /* Checking if coinTxt exists to prevent the following error:
         MissingReferenceException : The object of type 'Text' has been destroyed but you are still 
        trying to access it. You script should either check if it is null or should not destroy the object
         */



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
        //SceneManager.LoadScene(0); //index of the level I wanna load 
    }

}
