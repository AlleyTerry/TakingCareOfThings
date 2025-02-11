using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LeafCollision : MonoBehaviour
{
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
        if (leafOnStone == 0)
        {
            leafsOnStone = false;
            brush.SetActive(false);
            Debug.Log("no more leaves on stone!");
            FillHoleGame();
            PolishGame();
            EndGame();
        }
        else
        {
            ReturnButton.SetActive(false);
            text.text = "Clean the grave!";
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
            //for each crack, pick a random point from the list of crack points
            int randomIndex = UnityEngine.Random.Range(0, crackPoints.Count);
            //instantiate the crack at the random point
            Instantiate(crack, crackPoints[randomIndex].position, Quaternion.identity);
            crackNumber++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "crack")
                {
                    Destroy(hit.collider.gameObject);
                    crackNumber--;
                }
            }
            
        }
        
    }
    
    public void PolishGame()
    {
        text.text = "Polishing the stone!";
    }
    public void EndGame()
    {
        ReturnButton.SetActive(true);
        text.text = "All clean!";
    }
    
}
