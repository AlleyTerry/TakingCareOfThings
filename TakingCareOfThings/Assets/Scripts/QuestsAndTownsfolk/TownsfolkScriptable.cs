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
        outgoing,
        homebody,
        childish,
        adventurous
    }
    public Difficulty difficulty;
    [SerializeField] public enum Difficulty
    {
        easy,
        medium,
        hard
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
