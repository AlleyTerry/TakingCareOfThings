using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject buttonGroup;
    //create a choosenButton;
    public string chosenButton;
    //create a canvas isntance
    public static CanvasManager instance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //find the chosen button in the button group's children
        foreach (Transform child in buttonGroup.transform)
        {
            if (child.gameObject.name == chosenButton)
            {
                //if the child is the chosen button, set its image to active
                child.gameObject.GetComponent<Image>().enabled = true;
            }
        }
        
    }
}
