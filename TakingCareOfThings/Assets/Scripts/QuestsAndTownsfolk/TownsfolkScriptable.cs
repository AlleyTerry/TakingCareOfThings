using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(
    fileName = "New Townie",
    menuName = "ScriptableObjects/Townie",
    order = 2)]
public class TownsfolkScriptable : ScriptableObject
{
    public string townsfolkName;
    public string townsfolkDescription;

    public string townsfolkDialogue;
    public Image townsfolkPortrait;
    public bool hasBeenServed;
    public DeadPersonType deadPersonType;
    [SerializeField] public enum DeadPersonType
    {
        Childish,
        Homebody,
        Outgoing,
        Adventurous
    }
    public Difficulty difficulty;
    [SerializeField] public enum Difficulty
    {
        easy,
        medium,
        hard
    }

    public string Grave;
    public string Headstone;
    public string Flower1;
    public string Flower2;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
