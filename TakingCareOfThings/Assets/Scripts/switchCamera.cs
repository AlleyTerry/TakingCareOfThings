using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class switchCamera : MonoBehaviour
{
    public GameObject ThirdPersonCamera;
    public GameObject TopDownCamera;
    public GameObject WideTopDownCamera;
    public GameObject tabButton;
    public GameObject backButton;
    public CinemachineFreeLook cam;
    public GameObject GraveButtons;
    public GameObject flowerButtonGroup;
    public GameObject ordersButton;
    public TextMeshProUGUI score;
    public GameObject GraveSelectButtons;
    public string buttonName;
    public List<GameObject> gravePoints = new List<GameObject>();


    public GameObject player;
    
    public bool firstTime = true;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (tabButton.activeSelf)
            {
                tabButton.SetActive(false);
                Back();
            }
            else
            {
                tabButton.SetActive(true);
                Pause();
            }

            
        }
    }
    public void ThirdPersonCameraSwitch()
    {
        ThirdPersonCamera.SetActive(true);
        TopDownCamera.SetActive(false);
        WideTopDownCamera.SetActive(false);
        backButton.SetActive(false);
        GraveButtons.SetActive(false);
        Back();
        
    }
    
    public void WideTopDownCameraSwitch()
    {
        ThirdPersonCamera.SetActive(false);
        WideTopDownCamera.SetActive(true);
        tabButton.SetActive(false);
        GraveSelectButtons.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
        
        
    }
    
    public void TopDownCameraSwitch()
    {
        WideTopDownCamera.SetActive(false);
        TopDownCamera.SetActive(true);
        tabButton.SetActive(false);
        GraveSelectButtons.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = false;
        GraveButtons.SetActive(true);
        ordersButton.SetActive(true);
        if (firstTime)
        {
            //play the tutorial dialogue
            FindObjectOfType<DialogueRunner>().StartDialogue("GraveTutorial");
            firstTime = false;
            
        }
        
    }
    
    
    //function for choosing which grave to switch to
    public void GravePicker()
    {
        //get the name of the button that was pressed
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        //go through the grarve points and find the one that matches the button name
        foreach (var grave in gravePoints)
        {
            if (grave.name == buttonName)
            {
                //set the top down camera position to the grave point
                TopDownCamera.transform.position = grave.transform.position;
            }
        }
        //turn the top down camera on and the wide top down camera off
        TopDownCameraSwitch();
    }
    
    
    
    public void Pause()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        cam.enabled = false;
    }
    
    public void Back()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        cam.enabled = true;
        flowerButtonGroup.SetActive(false);
//        score.text = "SoulPoints: " + ScoreManager.instance.score;
  
    }
}
