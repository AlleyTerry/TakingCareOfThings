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
    [SerializeField] private Dictionary<string, string> blurbs = new Dictionary<string, string>();
   [SerializeField ]  private Dictionary<string, string> Childishblurbs = new Dictionary<string, string>();
    [SerializeField] private Dictionary<string, string> Homebodyblurbs = new Dictionary<string, string>();
    [SerializeField] private Dictionary<string, string> Outgoingblurbs = new Dictionary<string, string>();
    [SerializeField] private Dictionary<string, string> Adventurousblurbs = new Dictionary<string, string>();
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
    public PersonalityType personalityType;
    [SerializeField]public enum PersonalityType
    {
        //types of person
        Childish,
        Homebody,
        Outgoing,
        Adventurous
    }

    private int randomPersonality;
    // Start is called before the first frame update
    void Start()
    {
        
        DoneDoneButton.SetActive(false);
        //set the enum to a random value
        randomPersonality = Random.Range(0, 4);
        personalityType = (PersonalityType)randomPersonality;
        
        //ADD the blurbs based on the personality type
        if (personalityType == PersonalityType.Childish)
        {
            blurbs.Add("childish", "They really liked trains...");
            blurbs.Add("childish2", "They were never too old for cartoons...");
            blurbs.Add("childish3", "He thought he was the biggest joker..."); 
            blurbs.Add("childish4", "His he always had a lolipop in his mouth...");
            
        }
        else if (personalityType == PersonalityType.Homebody)
        {
            blurbs.Add("homebody", "You would never catch them at the club");
            blurbs.Add("homebody2", "Their room was always so cozy");
            blurbs.Add("homebody3", "They had the best taste in movies");
            blurbs.Add("homebody4", "You could always count on them for a good reccomendation");
            
        }
        else if (personalityType == PersonalityType.Outgoing)
        {
            blurbs.Add("outgoing", "He was always the life of the party");

        }
        else if (personalityType == PersonalityType.Adventurous)
        {
            blurbs.Add("adventurous", "She was always looking for the next thrill");
        }

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
