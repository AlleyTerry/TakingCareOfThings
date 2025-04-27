using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;



public class QuestManager : MonoBehaviour
{
    
    /// <summary>
    /// Has a list of townsfolk
    /// pulls a random townsfolk from the list of townsfolk
    /// at the start of each day
    /// it is going to decide how many towns folk are going to visit
    /// and how many rituals you have to do in the day 
    /// </summary>
    // Start is called before the first frame update
    public  List<TownsfolkScriptable> townsfolkList;
    public  int numberOfTownsfolk;
    public  int numberOfRituals;

    public  TownsfolkScriptable townsfolkChoosen;

    public  string townsfolkDialogue;
    //make this script an instance to be used in ScoreManager
    public static QuestManager instance;
    //yarnspinner variable set up
    private InMemoryVariableStorage variableStorage;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();
        
        if (!ScoreManager.instance.firstTimeOverworld && SceneManager.GetActiveScene().name == "Overworld")
        {
        
            //pick a random townsfolk from the list of townsfolk
            townsfolkChoosen = townsfolkList[Random.Range(0, townsfolkList.Count)];
            townsfolkDialogue = townsfolkChoosen.townsfolkDialogue;
            //play the townsfolk dialogue
            DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
            if (dialogueRunner != null)
            {
                variableStorage.SetValue("$townsfolkName", townsfolkDialogue);
                //dialogueRunner.StartDialogue(townsfolkDialogue);
            }
            else
            {
                Debug.LogError("DialogueRunner not found in the scene.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDayQuests(int lowerRange, int UpperRange)
    {
        //pick a random number within the range given
        //this range is set by ScoreManager based on the skepticism level
        numberOfTownsfolk = Random.Range(lowerRange, UpperRange);
        //pick a random number of rituals to do
        numberOfRituals = Random.Range(lowerRange, UpperRange);
    }
    
    [YarnCommand("GetTownsfolk")]
    public void GetTownsfolk()
    {
        //pick a random townsfolk from the list of townsfolk
        townsfolkChoosen = townsfolkList[Random.Range(0, townsfolkList.Count)];
        townsfolkDialogue = townsfolkChoosen.townsfolkDialogue;
        DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dialogueRunner != null)
        {
            variableStorage.SetValue("$townsfolkName", townsfolkDialogue);
            //dialogueRunner.StartDialogue(townsfolkDialogue);
        }
        else
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }
        
    }
    
    

}
