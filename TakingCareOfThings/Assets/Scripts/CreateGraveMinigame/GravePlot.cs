using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravePlot : MonoBehaviour
{
    public GameObject gravePlot;
    public bool isActive = false;
    //lists of grave plots
    public List<GameObject> gravePlots = new List<GameObject>();
    public static GravePlot instance;
    // Start is called before the first frame update
    void Start()
    {
        if (isActive)
        {
            gravePlot.SetActive(true);
        }
        else
        {
            gravePlot.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
