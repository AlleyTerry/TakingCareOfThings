using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class RitualManager : MonoBehaviour
{
    public int score = 0;
    public GameObject symbolButton;
    public GameObject ritualButton;
    public GameObject returnButton;
    public GameObject symbolsPanel;
    public TextMeshProUGUI timerText;
    public float timeRemaining = 5;
    public bool timerIsRunning = false;

    public GameObject symbolsGroup;
    public List<ScriptableObject> symbols = new List<ScriptableObject>();
    public GameObject item;
    public GameObject newitem;
    public String buttonName;

    public List<Transform> SymbolSlots = new List<Transform>();
    
    public List<ScriptableObject> holdSymbols = new List<ScriptableObject>();
    public List<TextMeshProUGUI> txtSlots = new List<TextMeshProUGUI>();
    public List<ScriptableObject> playerSymbols = new List<ScriptableObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            //int seconds = (int)(timeRemaining % 60);
            timerText.text = timeRemaining.ToString("F0");
            if (timeRemaining < 0)
            {
                timerText.text = "pick your symbols";
                timerIsRunning = false;
                symbolsGroup.SetActive(true);
                symbolsPanel.SetActive(false);
                PickSymbols();
            }
        }
    }
    
    public void GatherSymbolsStart()
    {
        symbolButton.SetActive(false);
        ritualButton.SetActive(true);
        timerIsRunning = true;
        for (int i = 0; i < 3; i++)
        {
            
            //pick random symbol from symbols list and add it to the new list
            int random = UnityEngine.Random.Range(0, symbols.Count);
            holdSymbols.Add(symbols[random]);
            //show the symbol names on screen
            for (int j = 0; j < txtSlots.Count; j++)
            {
                if (txtSlots[j].text == "")
                {
                    txtSlots[j].text = ((SymbolScriptable)holdSymbols[i]).symbolName;
                    break;
                }
                
            }
            
        }
        
    }
    
    public void PickSymbols()
    {
        //click buttons to add symbols to the list
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        foreach (var symbol in symbols)
        {
            if (symbol.name == buttonName)
            {
                item = ((SymbolScriptable)symbol).symbolPrefab;
                //go through slot and find an empty one
                for (int i = 0; i < SymbolSlots.Count; i++)
                {
                    if (SymbolSlots[i].childCount == 0)
                    {
                        //instantiate the item and set it to the slot
                        newitem = null;
                        newitem = Instantiate(item, SymbolSlots[i].position, Quaternion.identity);
                        newitem.transform.SetParent(SymbolSlots[i]);
                        newitem.GetComponent<Rigidbody>().isKinematic = true;
                        playerSymbols.Add(symbol);
                        break;
                    
                    }
                
                }
            }
            
        }
    }
    
    public void StartRitual()
    {
        symbolsGroup.SetActive(false);
        ritualButton.SetActive(false);
        returnButton.SetActive(true);

        timerText.text = "Ritual started";
        //check if the symbols are in the right order comapred to the hold symbols
        for (int i = 0; i < playerSymbols.Count; i++)
        {
               
                    if (((SymbolScriptable)playerSymbols[i]).symbolPrefab.name == ((SymbolScriptable)holdSymbols[i]).symbolPrefab.name)
                    {
                        Debug.Log("right");
                        score++;

                    }
                    else
                    {
                        Debug.Log("wrong");
                    
                    }
                
            
        }
    }
}
