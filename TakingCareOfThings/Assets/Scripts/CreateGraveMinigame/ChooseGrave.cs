using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "New GraveType",
    menuName = "ScriptableObjects/GraveObjects",
    order = 0)]
public class ChooseGrave : ScriptableObject
{
    public string graveName;
    public string graveDescription;
    public GameObject graveObject;
    public GraveType graveType;
    [SerializeField] public enum GraveType
    {
        black,
        blue,
        red,
        white
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
