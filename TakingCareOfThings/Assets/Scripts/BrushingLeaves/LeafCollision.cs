using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LeafCollision : MonoBehaviour
{
    public int leafOnStone = 0;
    
    public GameObject ReturnButton;
    public TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Clean the grave!";
        ReturnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (leafOnStone == 0)
        {
            Debug.Log("no more leaves on stone!");
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
        if (other.gameObject.tag == "leaf")
        {
            leafOnStone += 1;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "leaf")
        {
            leafOnStone -= 1;
        }
    }
    
    public void EndGame()
    {
        ReturnButton.SetActive(true);
        text.text = "All clean!";
    }
    
}
