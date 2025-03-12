using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReesePathing : MonoBehaviour
{
    public List<GameObject> gravePlots = new List<GameObject>();

    public GameObject pickedGravePlot;
    
    public NavMeshAgent agent;
    public float destinationThreshold = 0.1f;
    
    public bool foundGrave = false;
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
        if (agent.remainingDistance <= destinationThreshold)
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
        //play the digging animation
        //start a timer
        timer -= Time.deltaTime;
        //after the timer is done, set the grave to active
        if (timer <= 0)
        {
            pickedGravePlot.SetActive(true);
            //set the choosen button name
            CanvasManager.chosenButton = pickedGravePlot.name;
            foundGrave = false;
            timer = 5f;
            
        }
    }
    
}
