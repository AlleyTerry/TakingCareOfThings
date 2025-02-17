using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Symbol",
                menuName = "ScriptableObjects/SymbolScriptable",
                order = 1)]
public class SymbolScriptable : ScriptableObject
{
    public string symbolName;
    public string symbolDescription;
    public GameObject symbolPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
