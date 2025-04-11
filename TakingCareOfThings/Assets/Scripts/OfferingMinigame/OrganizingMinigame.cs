using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using Random = UnityEngine.Random;

public class OrganizingMinigame : MonoBehaviour
{
    //[SerializeField] private List<GameObject> blurbs = new List<GameObject>();
    public Offering objectNameType;
   [SerializeField ]  private Dictionary<string, string> blurbs = new Dictionary<string, string>();
    public TextMeshProUGUI blurbText;
    private string randomKey;
    private string itemKey;
    public GameObject offeringObject;
    public GameObject DoneDoneButton;
    public GameObject NextNextButton;
    public GameObject ReturnButton;
    public TextMeshProUGUI score;
    //public ParticleSystem explosionEffect;
    public ParticleSystem explosionEffect;
    public GameObject explosionffectPrefab;
    public float timer;
    public TextMeshProUGUI timerText;
    public bool timerStarted = false;
  
    // Start is called before the first frame update
    void Start()
    {
        DoneDoneButton.SetActive(false);
        
        blurbs.Add("childish", "He never seemed to grow up");
        blurbs.Add("homebody", "You would never catch her at the club");
        blurbs.Add("outgoing", "He was always the life of the party");
        blurbs.Add("adventurous", "She was always looking for the next thrill");
        int randomNum = Random.Range(0, blurbs.Keys.Count-1);
        //print(randomNum);
        randomKey = blurbs.Keys.ElementAt(randomNum);
        blurbText.text = blurbs[randomKey];
        score.text = "SoulPoints: " + ScoreManager.score;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            startTimer();
        }
        if (blurbs == null)
        {
            
            blurbText.text = "You win!";
        }

        if (timer <= 0)
        {
            //stop timer
            timerStarted = false;
            blurbText.text = "Times up!";
            //return to main game
            ReturnButton.SetActive(true);
            NextNextButton.SetActive(false);
            DoneDoneButton.SetActive(false);
        }
        else
        {
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Transform rootTransform = other.transform.root;
        GameObject rootObject = rootTransform.gameObject;
        offeringObject = rootObject;
        
        objectNameType = offeringObject.GetComponent<Offering>();

        itemKey = objectNameType.offering.offeringType.ToString();
        print(itemKey);
    }

    /*public void OnCollisionEnter(Collision other)
    {
        offeringObject = other.gameObject;
        
        objectNameType = offeringObject.GetComponent<Offering>();

        itemKey = objectNameType.offering.offeringType.ToString();
        print(itemKey);
      
    }*/

    public void DoneButton()
    {
        if (itemKey == randomKey)
        {
            blurbText.text = "Correct!";
            ScoreManager.score += 1;
            score.text = "SoulPoints: " + ScoreManager.score;
            //instantiate the a particle effect on the object
            GameObject explosionObject = Instantiate(explosionffectPrefab, offeringObject.transform.position, Quaternion.identity);
            explosionEffect = explosionObject.GetComponent<ParticleSystem>();
            //Destroy the object and the particle effect after 1 second
            Destroy(explosionObject, 1f);
            Destroy(offeringObject);
        }
        else
        {
            blurbText.text = "Incorrect!";
        }
        blurbs.Remove(randomKey);
        foreach (var i in blurbs.Values)
        {
            Debug.Log(i);
        }
        NextNextButton.SetActive(true);
        DoneDoneButton.SetActive(false);
    }

    public void NextButton()
    {
        if (blurbs.Count == 0) 
        {
            //stop timer
            timerStarted = false;
            timerText.text = "Time Left: ";
            blurbText.text = "You win!";
            NextNextButton.SetActive(false);
            ReturnButton.SetActive(true);
        }
        else
        {
            int randomNum = Random.Range(0, blurbs.Keys.Count-1);
            //print(randomNum);
            randomKey = blurbs.Keys.ElementAt(randomNum);
            blurbText.text = blurbs[randomKey];
            NextNextButton.SetActive(false);
            DoneDoneButton.SetActive(true);
        }
    }

    [YarnCommand("startMinigame")]
    public void startMinigame()
    {
        DoneDoneButton.SetActive(true);
        //start timer
        timerStarted = true;
    }

    public void startTimer()
    {
        //run timer countdown
        timer -= Time.deltaTime;
        //timer text
        timerText.text = "Time Left: " + Mathf.Round(timer);
    }
}
