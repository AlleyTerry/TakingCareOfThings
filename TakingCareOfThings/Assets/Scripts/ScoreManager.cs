using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static int score ;
    
    public static String buddy;
    public bool newDayStarted = false;
    public bool firstTimeOverworld = true;
    public bool firstTimeSorting = true;
    public bool firstTimeOffering = true;
    public int SkepticMeter = 90;
    /// <summary>
    /// you have a cetrain number of rituals to do everyday 
    /// you have a certain number of tasks every day depending on your skeptic meter
    /// you want your skeptic to be as high as possible
    /// if ur skeptic meter is between 70 and 100, the towns folk only come around once a day
    /// meaning you will only have to do 1 or 2 tasks to do
    /// however the lower range your skeptic meter gets, you will have to do more tasks
    /// 40 - 69 = 3 tasks
    /// 0-39 = 4 tasks
    /// you only have a certain amount of time allowence each day for different tasks
    /// maybe you start out the day with 4 soul points
    /// this is what you will spend both to do tasks and to also keep your buddies alive
    /// your main task is to do rituals on your buddies to keep them and yourself alive
    /// these cost soul points
    /// but so does doing tasks
    /// the main goal of the game is to keep your buddies alive for as long as possible
    /// and also not get caught by the townsfolk
    /// you will loose :)
    /// </summary>
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
      
    }

    // Start is called before the first frame update
    void Start()
    {
            //start yarn dialogue
            if (firstTimeOverworld && SceneManager.GetActiveScene().name == "Overworld")
            {
                //play the tutorial dialogue
                firstTimeOverworld = false;
                FindObjectOfType<DialogueRunner>().StartDialogue("StartOverworld");
            }
            else if (firstTimeSorting && SceneManager.GetActiveScene().name == "SortingMinigame")
            {
                //play the tutorial dialogue
                firstTimeSorting = false;
                FindObjectOfType<DialogueRunner>().StartDialogue("SortingMinigame");
            }
            else if (firstTimeOffering && SceneManager.GetActiveScene().name == "OfferingMinigame")
            {
                //play the tutorial dialogue
                firstTimeOffering = false;
                FindObjectOfType<DialogueRunner>().StartDialogue("MiniGameTutorial");
            }

            
        
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SkepticMeter <= 0)
        {
            //if the player has no more skeptic meter, end the game
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
