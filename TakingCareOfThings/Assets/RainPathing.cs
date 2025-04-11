using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;
using Cinemachine;

public class RainPathing : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject dialgoueRunner;

    public GameObject minigameButtons;
    public GameObject player;

    public CinemachineFreeLook cam;

    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject Point4;
    
    public float destinationThreshold = 0.1f;
        
    public bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the dialogue runner
        dialgoueRunner = GameObject.Find("Dialogue System").gameObject;
        agent = GetComponent<NavMeshAgent>();
        //find player
        player = GameObject.Find("Player2").gameObject;
        minigameButtons = GameObject.Find("MiniGameButtons").gameObject;
        minigameButtons.SetActive(false);
        
        cam = GameObject.Find("FreeLook Camera").GetComponent<CinemachineFreeLook>();
        
        //find the points
        Point1 = GameObject.Find("Point1").gameObject;
        Point2 = GameObject.Find("Point2").gameObject;
        Point3 = GameObject.Find("Point3").gameObject;
        Point4 = GameObject.Find("Point4").gameObject;
        //set the destination to point 1
       // agent.SetDestination(Point1.transform.position);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //initalize the objects 
        if (collided)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("game paused");
                PauseGame();
            }
           
            
        }
        
        /*// go between the points
        if (agent.remainingDistance <= destinationThreshold)
        {
            agent.SetDestination(Point2.transform.position);
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with " + other.gameObject.name);
            collided = true;
            
            
        }
    }
    
    public void PauseGame()
    {
        collided = false;
        Camera.main.GetComponent<ThirdPersonMovement>().enabled = false;
        cam.enabled = false; 
        player.GetComponent<PlayerMovement>().enabled = false;
        dialgoueRunner.GetComponent<DialogueRunner>().StartDialogue("RainMinigame");
    }
    
    [YarnCommand("TurnOnButtons")]
    public void TurnOnButtons()
    {
        minigameButtons.SetActive(true);

    }
    
}
