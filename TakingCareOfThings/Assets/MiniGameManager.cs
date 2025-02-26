using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public List<ScriptableObject> graves = new List<ScriptableObject>();
    public List<ScriptableObject> headstones = new List<ScriptableObject>();
    public List<ScriptableObject> flowers = new List<ScriptableObject>();


    public ScriptableObject Grave;
    public ScriptableObject Headstone;
    public ScriptableObject Flower1;
    public ScriptableObject Flower2;
    
    public TMPro.TextMeshProUGUI score;

   // public static MiniGameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log(Grave.name);
        Debug.Log(Headstone.name);
        Debug.Log(Flower1.name);
        Debug.Log(Flower2.name);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SoulPoints: " + ScoreManager.score;
    }
}
