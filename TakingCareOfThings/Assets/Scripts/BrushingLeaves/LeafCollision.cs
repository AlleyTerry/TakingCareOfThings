using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LeafCollision : MonoBehaviour
{
    public GameObject newCrack;
    public int leafOnStone = 0;
    
    public GameObject ReturnButton;
    public TMPro.TextMeshProUGUI text;
    public GameObject brush;
    public List<Transform> crackPoints = new List<Transform>();
    public GameObject crack;
    public int crackNumber = 0;
    public bool leafsOnStone = false;
    public bool fillHole = false;
    public bool polish = false;
    public float pickUpRange = 10f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Clean the grave!";
        ReturnButton.SetActive(false);
        leafsOnStone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (leafOnStone > 0)
        {
            ReturnButton.SetActive(false);
            text.text = "Clean the grave!";
        }
        if (leafOnStone == 0 && leafsOnStone)   
        {
            leafsOnStone = false;
            brush.SetActive(false);
            //Debug.Log("no more leaves on stone!");
            FillHoleGame();
            //PolishGame();
            //EndGame();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, pickUpRange))
            {
                if (hit.transform.CompareTag("crack"))
                {
                    Debug.Log("hit a crack");
                    Destroy(hit.collider.gameObject);
                    crackNumber--;
                }
            }
            
        }
        if (crackNumber == 0 && fillHole)
        {
            fillHole = false;
            polish = true;
            PolishGame();
            //EndGame();
        }
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "leaf" && leafsOnStone)
        {
            leafOnStone += 1;
        }
   
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "leaf" && leafsOnStone)
        {
            leafOnStone -= 1;
        }
    }
    
    public void FillHoleGame()
    {
        fillHole = true;
        text.text = "Fill the cracks!";
        //instantiates random "cracks" on the stone
        //does this 3 times
        for (int i = 0; i < 3; i++)
        {
            if (newCrack != null)
            {
                //choose a random crack point
                int randomIndex = UnityEngine.Random.Range(0, crackPoints.Count);
                //if the random index is the same as the index of the last crack, choose a new random index
                while (crackPoints[randomIndex].transform.childCount > 0)
                {
                    randomIndex = UnityEngine.Random.Range(0, crackPoints.Count);
                }
                
                newCrack = Instantiate(crack, crackPoints[randomIndex].position, Quaternion.identity);
                newCrack.transform.SetParent(crackPoints[randomIndex]);
                crackNumber++;
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, crackPoints.Count);
                newCrack = Instantiate(crack, crackPoints[randomIndex].position, Quaternion.identity);
                newCrack.transform.SetParent(crackPoints[randomIndex]);
                crackNumber++;
            }
            //for each crack, pick a random point from the list of crack points
            //instantiate the crack at the random point
            
        }

        
        
    }
    
    public void PolishGame()
    {
        text.text = "Polish the stone!";
    }
    public void EndGame()
    {
        ReturnButton.SetActive(true);
        text.text = "All clean!";
    }
    
}
