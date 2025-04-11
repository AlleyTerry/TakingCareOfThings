using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class ScoreManager : MonoBehaviour
{
    
    public static int score = 0;
    public static ScoreManager instance;
    public static String buddy;
    public bool newDayStarted = false;
    public bool firstTimeOverworld = true;
    public bool firstTimeSorting = true;
    public bool firstTimeOffering = true;
    
    public void Awake()
    {
        if (instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Duplicate ScoreManager destroyed.");
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
                FindObjectOfType<DialogueRunner>().StartDialogue("OfferingMinigame");
            }
           
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
