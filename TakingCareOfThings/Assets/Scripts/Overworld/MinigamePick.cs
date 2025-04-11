using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MinigamePick : MonoBehaviour
{
    
    public GameObject buttons;
    public GameObject player;
    public CinemachineFreeLook cam;
    public GameObject playerCollider;
    public bool collided = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
        if (Input.GetKeyDown(KeyCode.Return) && collided && cam.enabled)
        {   
            
            PauseMiniGame();
        }
      
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other.gameObject.name);
        collided = true;
        
    }
    



    public void SortingMinigame()
    {
        buttons.SetActive(false);
        ES3AutoSaveMgr.Current.Save();
        SceneManager.LoadScene("SortingMinigame");
        
    }
    
    public void OfferingMinigame()
    {
        buttons.SetActive(false);
        ES3AutoSaveMgr.Current.Save();
        SceneManager.LoadScene("OfferingMinigame");
    }
    
    public void Back()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = true;
        cam.enabled = true; 
        player.GetComponent<PlayerMovement>().enabled = true;
        buttons.SetActive(false);
    }

    public void PauseMiniGame()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = false;
        cam.enabled = false; 
        player.GetComponent<PlayerMovement>().enabled = false;
        if (collided)
        {
            buttons.SetActive(true);
            collided = false;
        }
    }
}
