using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using Random = UnityEngine.Random;

public class SortingMinigame : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timerText;
    public bool timerStarted = false;
    public ParticleSystem explosionEffect;
    public GameObject explosionffectPrefabCorrect;
    public GameObject explosionffectPrefabWrong;
    public TextMeshProUGUI score;
    public GameObject sortingObjectManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == this.tag)
        {
            Debug.Log("correct bin!");
            ScoreManager.score += 1;
            //play explosion effect
            GameObject explosionObject = Instantiate(explosionffectPrefabCorrect, other.transform.position, Quaternion.identity);
            explosionEffect = explosionObject.GetComponent<ParticleSystem>();
            //destroy explosion effect after 2 seconds
            Destroy(explosionObject.gameObject, 2f);
            //destroy object
            Destroy(other.gameObject);
            score.text = "SoulPoints: " + ScoreManager.score;
            //get sorting objects list
            SortingObjectsList sortingObjectsList = sortingObjectManager.GetComponent<SortingObjectsList>();
            if (sortingObjectsList.SortoObjects != null)
            {
                //remove object from list
                sortingObjectsList.SortoObjects.Remove(other.gameObject);
                //pick a random object from the list and instantiate it
                int randomNum = UnityEngine.Random.Range(0, sortingObjectsList.SortoObjects.Count);
                GameObject randomObject = Instantiate(sortingObjectsList.SortoObjects[randomNum], new Vector3(0, 0, 0), Quaternion.identity);
            }
          
            
        }
        else
        {
            Debug.Log("wrong bin!");
            //play explosion effect
            GameObject explosionObject = Instantiate(explosionffectPrefabWrong, other.transform.position, Quaternion.identity);
            explosionEffect = explosionObject.GetComponent<ParticleSystem>();
            //destroy explosion effect after 2 seconds
            Destroy(explosionObject.gameObject, 2f);
            //destroy object
            Destroy(other.gameObject);
            //get sorting objects list
            SortingObjectsList sortingObjectsList = sortingObjectManager.GetComponent<SortingObjectsList>();
            if (sortingObjectsList.SortoObjects != null)
            {
                //remove object from list
                sortingObjectsList.SortoObjects.Remove(other.gameObject);
                //pick a random object from the list and instantiate it
                int randomNum = UnityEngine.Random.Range(0, sortingObjectsList.SortoObjects.Count);
                GameObject randomObject = Instantiate(sortingObjectsList.SortoObjects[randomNum], new Vector3(0, 0, 0), Quaternion.identity);
            }
         
        }
    }

}
