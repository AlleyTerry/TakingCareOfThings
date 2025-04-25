using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "New Offering",
    menuName = "ScriptableObjects/OfferingObjects",
    order = 0)]
public class OfferingObjects : ScriptableObject
{
    public string offeringName;
    public string offeringDescription;
    public OfferingType offeringType;
    [SerializeField] public enum OfferingType
    {
        outgoing,
        homebody,
        childish,
        adventurous
    }
    public GameObject offeringObject;
    public string offeringBlurb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
