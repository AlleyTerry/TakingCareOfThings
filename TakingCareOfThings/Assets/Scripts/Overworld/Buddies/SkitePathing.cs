using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SkitePathing : MonoBehaviour
{
    public List<GameObject> weeds = new List<GameObject>();

    public GameObject pickedWeed;
    
    public NavMeshAgent agent;
    public float destinationThreshold = 0.1f;
    
    public bool foundWeed = false;
    public float timer = 20f;
    
   
    public bool isWalking = true;
    // Start is called before the first frame update
    void Start()
    {
        //find all the weeds under the Weeds Game objects
        foreach (Transform child in GameObject.Find("Weeds").transform)
        {
            weeds.Add(child.gameObject);
        }
        
        //pick a random weed
        pickedWeed = weeds[Random.Range(0, weeds.Count)].gameObject;
        //go to that weed
        agent.SetDestination(pickedWeed.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the agent is close to the destination, set foundWeed to true
        if (agent.remainingDistance <= destinationThreshold && isWalking)
        {
            Debug.Log("Found Weed");
            foundWeed = true;
        }
        if (foundWeed)
        {
            //start the function of digging weed
            StartPicking();
        }
        
    }

    public void StartPicking()
    {
        isWalking = false;
        //play weed picking animation
        //start timer
        if (foundWeed)
        {
            timer = 20f;
            timer -= Time.deltaTime;
        }
        //if timer is less than 0, pick the weed
        if (timer <= 0)
        {
            //remove the weed from the list
            weeds.Remove(pickedWeed);
            //destroy the weed
            Destroy(pickedWeed);
            ScoreManager.instance.SkepticMeter += 1;
            //set the text to the new value
            GameObject.Find("SkepticMeter").GetComponentInChildren<TextMeshProUGUI>().text = "Reputation: " + ScoreManager.instance.SkepticMeter;
            Debug.Log("skite added a point");
            //reset timer
            
            if (weeds.Count > 0)
            {
                //pick a new weed
                pickedWeed = weeds[Random.Range(0, weeds.Count)].gameObject;
                //go to that weed
                agent.SetDestination(pickedWeed.transform.position);
                isWalking = true;
                
            }
            else
            {
                Debug.Log("No more weeds");
            }
        }
        
    }
}
