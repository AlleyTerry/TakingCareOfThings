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
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
        //set up collision
        if (Input.GetKeyDown(KeyCode.Return) &&
            gameObject.GetComponent<Collider>().bounds.Contains(playerCollider.transform.position)) 
        {
            Pause();
            
        }
    }
    

    public void flower()
    {
        ES3AutoSaveMgr.Current.Save();
        SceneManager.LoadScene(1);
        
    }
    
    public void leaves()
    {
        ES3AutoSaveMgr.Current.Save();
        SceneManager.LoadScene(2);
    }
    
    public void Back()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = true;
        cam.enabled = true; 
        player.GetComponent<PlayerMovement>().enabled = true;
        buttons.SetActive(false);
    }

    public void Pause()
    {
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = false;
        cam.enabled = false; 
        player.GetComponent<PlayerMovement>().enabled = false;
        buttons.SetActive(true);
    }
}
