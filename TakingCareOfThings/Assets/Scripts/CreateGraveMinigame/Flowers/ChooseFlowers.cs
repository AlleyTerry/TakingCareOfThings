using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New GraveType",
    menuName = "ScriptableObjects/FlowerObjects",
    order = 0)]
public class ChooseFlowers : ScriptableObject
{
    public string flowerName;
    public string flowerDescription;
    public GameObject flowerObject;
    public FlowerType flowerType;
    [SerializeField] public enum FlowerType
    {
        roses,
        daises,
        lilies,
        sunflowers
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
