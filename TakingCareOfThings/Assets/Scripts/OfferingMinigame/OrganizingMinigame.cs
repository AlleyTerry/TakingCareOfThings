using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
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
   
  
    // Start is called before the first frame update
    void Start()
    {
        
        blurbs.Add("childish", "He never seemed to grow up");
        blurbs.Add("homebody", "You would never catch her at the club");
        blurbs.Add("outgoing", "He was always the life of the party");
        blurbs.Add("adventurous", "She was always looking for the next thrill");
        int randomNum = Random.Range(0, blurbs.Keys.Count-1);
        //print(randomNum);
        randomKey = blurbs.Keys.ElementAt(randomNum);
        blurbText.text = blurbs[randomKey];
        score.text = "SoulPoints: " + ScoreManager.instance.score;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (blurbs == null)
        {
            blurbText.text = "You win!";
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        offeringObject = other.gameObject;
        
        objectNameType = offeringObject.GetComponent<Offering>();

        itemKey = objectNameType.offering.offeringType.ToString();
        print(itemKey);
      
    }

    public void DoneButton()
    {
        if (itemKey == randomKey)
        {
            blurbText.text = "Correct!";
            ScoreManager.instance.score += 1;
            score.text = "SoulPoints: " + ScoreManager.instance.score;
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
}
