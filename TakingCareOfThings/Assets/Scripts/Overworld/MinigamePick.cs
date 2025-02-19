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
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
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
