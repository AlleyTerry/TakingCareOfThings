using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Buddy",
    menuName = "ScriptableObjects/Buddies",
    order = 0)]

public class BuddiesScriptables : ScriptableObject
{
    public string buddyName;
    public string buddyDescription;
    public GameObject buddyObject;
    public int buddyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
