using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class switchCamera : MonoBehaviour
{
    public GameObject ThirdPersonCamera;
    public GameObject TopDownCamera;
    public GameObject tabButton;
    public GameObject backButton;
    public CinemachineFreeLook cam;
    public GameObject GraveButtons;
    public GameObject flowerButtonGroup;


    public GameObject player;


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
        backButton.SetActive(false);
        GraveButtons.SetActive(false);
        Back();
        
    }
    
    public void TopDownCameraSwitch()
    {
        ThirdPersonCamera.SetActive(false);
        TopDownCamera.SetActive(true);
        tabButton.SetActive(false);
        //backButton.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
        GraveButtons.SetActive(true);
        
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
  
    }
}
