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

    private StringBuilder timerString = new StringBuilder(); //to use a string builder we have to declare it

    private bool gameOver;

    [SerializeField]
    private GameObject gameOverPanel;

    private void Awake()
    {
        if (instance != null)
        {

        }

    }





}
