using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OverworldManager : MonoBehaviour
{
    // set the sky box to night
    //set the ritual board to active
    //let the player choose who they want to do the ritual for
    
    public GameObject ritualBoard;
    public Material skyboxDay;
    public Material skyboxNight;
    public Light sun;
    public CinemachineFreeLook cam;

    public ScriptableObject choosenBuddy;

    public GameObject BuddyChooseButtons;
    public GameObject player;
    public String choosenBuddyButton;
    
    public ScriptableObject buddy1;
    public ScriptableObject buddy2;
    public ScriptableObject buddy3;
    public GameObject buddy1Object;
    public GameObject buddy2Object;
    public GameObject buddy3Object;
    public TextMeshProUGUI Reese;
    public TextMeshProUGUI Rain;
    public TextMeshProUGUI Skite;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public GameObject yesNoButton;


    public GameObject weedPrefab;
    public GameObject Weeds;
    // Start is called before the first frame update
    void Start()
    {
        //instantiates the buddies
        buddy1Object = Instantiate(((BuddiesScriptables)buddy1).buddyObject, point1.position, Quaternion.identity);
        buddy2Object = Instantiate(((BuddiesScriptables)buddy2).buddyObject, point2.position, Quaternion.identity);
        buddy3Object = Instantiate(((BuddiesScriptables)buddy3).buddyObject, point3.position, Quaternion.identity);
        //take away health from scriptable object
        if (ScoreManager.instance.newDayStarted)
        {
            ((BuddiesScriptables)buddy1).buddyHealth -= 3;
            ((BuddiesScriptables)buddy2).buddyHealth -= 3;
            ((BuddiesScriptables)buddy3).buddyHealth -= 3;
            ScoreManager.instance.newDayStarted = false;
            //set skybox to day
            //set lighting to normal
            RenderSettings.skybox = skyboxDay;
            sun.intensity = 1.0f;
        }
      
        
        SpawnWeeds();

    }

    public void SpawnWeeds()
    {
        //instantiates weeds in random positions within a boundry?
        
        for (int i = 0; i < 10; i++)
        {
            //randomize the position of the weed without choosing the same position as another weed\
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-10, 10), -0.301f, UnityEngine.Random.Range(5, 17));
            while (randomPosition == new Vector3(UnityEngine.Random.Range(-10, 10), -0.301f, UnityEngine.Random.Range(5, 17)))
            {
                randomPosition = new Vector3(UnityEngine.Random.Range(-10, 10), -0.301f, UnityEngine.Random.Range(5, 17));
            }
            

            GameObject weed = Instantiate(weedPrefab, randomPosition, Quaternion.Euler(-90, 0, 0));
            weed.transform.parent = Weeds.transform;
                
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        SoulPointsUpdate();
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRitual();
        }
        //if the player is colliding with the ritual board and presses enter make the buddy button active
        if (Input.GetKeyDown(KeyCode.Return) && ritualBoard.GetComponent<Collider>().bounds.Contains(player.transform.position))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
     
        
    }

    public void SoulPointsUpdate()
    {
        //update the soul points of each buddy
        Reese.text = "Reese: " + ((BuddiesScriptables)buddy1).buddyHealth;
        Rain.text = "Rain: " + ((BuddiesScriptables)buddy2).buddyHealth;
        Skite.text = "Skite: " + ((BuddiesScriptables)buddy3).buddyHealth;
    }
    
    
    public void StartRitual()
    {
        //set the sky box to night
        //set the ritual board to active
        //let the player choose who they want to do the ritual for
        //turn down the lighting
        sun.intensity = 0.25f;
        RenderSettings.skybox = skyboxNight;
        ritualBoard.SetActive(true);
        
    }

    public void GoToRitual()
    {
        //set the name of the buddy choosen in score manager based off the button pressed
        //go to the ritual scene
        choosenBuddyButton = EventSystem.current.currentSelectedGameObject.name;
        ScoreManager.buddy = choosenBuddyButton;
        Debug.Log(choosenBuddyButton);
        yesNoButton.SetActive(true);
        BuddyChooseButtons.SetActive(false);
        //SceneManager.LoadScene("Ritual");

    }
    
    public void Back()
    {
        BuddyChooseButtons.SetActive(false);
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = true;
        cam.enabled = true; 
        player.GetComponent<PlayerMovement>().enabled = true;
        
    }

    public void Pause()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = false;
        cam.enabled = false; 
        player.GetComponent<PlayerMovement>().enabled = false;
        BuddyChooseButtons.SetActive(true);
    }
    
    public void Yes()
    {
        SceneManager.LoadScene("Ritual");
    }

    public void No()
    {
        yesNoButton.SetActive(false);
        BuddyChooseButtons.SetActive(true);
        
    }
}
