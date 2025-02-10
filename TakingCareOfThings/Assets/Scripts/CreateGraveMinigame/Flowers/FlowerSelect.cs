using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowerSelect : MonoBehaviour
{
    public List<ScriptableObject> flowers = new List<ScriptableObject>();
    public GameObject item;
    public float offset = 3f;
    public GameObject newitem;
    public GameObject parentItem;
    public String buttonName;
   

    public Camera TopDownCamera;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
                
            }
            
            if (newitem != null )
            {
                newitem.GetComponent<Rigidbody>().isKinematic = false;
                newitem.transform.SetParent(null);
            }
            
            
        }
    }
    
    public void SelectItem()
    {
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (newitem != null)
        {
            Destroy(newitem.gameObject);
        }

        foreach (var stone in flowers)
        {
            if (stone.name == buttonName)
            {
                item = ((ChooseFlowers) stone).flowerObject;
            }
        }
        
        newitem = null;
        newitem = Instantiate(item, parentItem.transform.position, Quaternion.identity);
        newitem.transform.SetParent(parentItem.transform);
        newitem.GetComponent<Rigidbody>().isKinematic = true;
    }
    
 
}
