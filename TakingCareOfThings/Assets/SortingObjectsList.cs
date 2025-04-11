using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingObjectsList : MonoBehaviour
{
    //list of objects
    public List<GameObject> SortoObjects = new List<GameObject>();
    public static SortingObjectsList instance;
    // Start is called before the first frame update
    void Start()
    {
        //pick a random object from the list and instantiate it
        int randomNum = UnityEngine.Random.Range(0, SortoObjects.Count);
        GameObject randomObject = Instantiate(SortoObjects[randomNum], new Vector3(0, 0, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
