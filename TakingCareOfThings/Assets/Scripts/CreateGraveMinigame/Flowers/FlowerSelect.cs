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
    public int flowerCount;
    public GameObject secondFlower;

    public Camera TopDownCamera;
    
    public List<Transform> snapPoints = new List<Transform>();
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
                SnapToNearestPoint(newitem);
                newitem.GetComponent<Rigidbody>().isKinematic = true;
                secondFlower = newitem;
                newitem = null;
            }
            
            
        }
    }
    public void SnapToNearestPoint(GameObject item)
    {
        Transform closestSnapPoint = null;
        float closestDistance = Mathf.Infinity;
        foreach (var snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(item.transform.position, snapPoint.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSnapPoint = snapPoint;
            }
        }

        if (closestSnapPoint != null)
        { 
            item.transform.position = closestSnapPoint.position + new Vector3(0, 0.5f, 0);
        }
    }
    
    public void SelectItem()
    {
        if (flowerCount <= 1)
        {
            buttonName = EventSystem.current.currentSelectedGameObject.name;
            if (newitem != null )
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
    
 
}
