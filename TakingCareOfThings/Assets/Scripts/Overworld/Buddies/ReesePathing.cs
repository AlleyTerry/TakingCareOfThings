using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ReesePathing : MonoBehaviour
{
    public List<GameObject> gravePlots = new List<GameObject>();

    public GameObject pickedGravePlot;
    
    public NavMeshAgent agent;
    public float destinationThreshold = 0.1f;
    
    public bool foundGrave = false;
    public bool isWalking = true;
    public float timer = 5f;
    
    public CanvasManager CanvasManager;
    // Start is called before the first frame update
    void Start()
    {
        //initialize the canvas manager
        CanvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        //go through the child of GravePlots a  list of all the grave plots
        foreach (Transform child in GameObject.Find("GravePlots").transform)
        {
            gravePlots.Add(child.gameObject);
        }
        
        //pick a random grave plot
        pickedGravePlot = gravePlots[Random.Range(0, gravePlots.Count)].gameObject;
        //while that grave plot is active, pick another one that is not active
        while (pickedGravePlot.GetComponent<GravePlot>().isActive)
        {
            pickedGravePlot = gravePlots[Random.Range(0, gravePlots.Count)].gameObject;
        }
        //if the plot is not active, move to it
        if (pickedGravePlot.GetComponent<GravePlot>().isActive == false)
        {
            agent.SetDestination(pickedGravePlot.transform.position);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the agent is close to the destination, set foundGrave to true
        if (agent.remainingDistance <= destinationThreshold && isWalking)
     
        {
            Debug.Log("Found Grave");
            foundGrave = true;
        }
        if (foundGrave)
        {
            
            //start the function of digging grave
            StartDigging();
        }
    }

    public void StartDigging()
    {
        isWalking = false;
        //play the digging animation
        //start a timer
        if (foundGrave )
        {
            timer -= Time.deltaTime;
        }
        //after the timer is done, set the grave to active
        if (timer <= 0)
        {
            foundGrave = false;
            pickedGravePlot.SetActive(true);
            //set the choosen button name
            CanvasManager.chosenButton = pickedGravePlot.name;
            ScoreManager.instance.SkepticMeter += 5;
            GameObject.Find("SkepticMeter").GetComponentInChildren<TextMeshProUGUI>().text = "Reputation: " + ScoreManager.instance.SkepticMeter;
            Debug.Log("reese added a point");

        }
    }
    
}
