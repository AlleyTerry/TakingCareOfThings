using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New GraveType",
    menuName = "ScriptableObjects/HeadStoneObjects",
    order = 0)]
public class ChooseHeadstone : ScriptableObject
{
    public string headstoneName;
    public string headstoneDescription;
    public GameObject headstoneObject;
    public StoneType stoneType;
    [SerializeField] public enum StoneType
    {
        cube,
        cylinder,
        sphere,
        capsule
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
