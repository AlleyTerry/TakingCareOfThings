using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class SortingGameManager : MonoBehaviour
{
    public float timer = 60f;
    public TextMeshProUGUI timerText;
    public bool timerStarted = false;
    public GameObject returnButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            startTimer();
        }
        if (timer <= 0)
        {
            //stop timer
            timerStarted = false;
            //change timer text
            timerText.text = "Time's Up!";
            returnButton.SetActive(true);
        }
        
    }
    
        
    [YarnCommand("StartTheGame")]
    public void StartTheGame()
    {
        //start timer
        timerStarted = true;
    }
    public void startTimer()
    {
        //run timer countdown
        timer -= Time.deltaTime;
        //timer text
        timerText.text = "Time Left: " + Mathf.Round(timer);
    }

}
