using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//coffin script
public class ItemSelect : MonoBehaviour
{
    public List<ScriptableObject> graves = new List<ScriptableObject>();
    public GameObject item;
    public float offset = 3f;
    public GameObject newitem;
    public GameObject parentItem;
    public String buttonName;
    public GameObject graveGroupButtons;
    public GameObject headstoneGroupButtons;
    public GameObject MiniGameManager;
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI orderText;

    public Camera TopDownCamera;
    public String choosenGrave;
    
    public List<Transform> snapPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        choosenGrave = MiniGameManager.GetComponent<MiniGameManager>().Grave.name;
        Debug.Log(choosenGrave);
        orderText.text = choosenGrave;


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
            
            //drop object
            if (newitem != null )
            {
                    newitem.GetComponent<Rigidbody>().isKinematic = false;
                    newitem.transform.SetParent(null);
                    SnapToNearestPoint(newitem);
                    newitem.GetComponent<Rigidbody>().isKinematic = true;
                    
            }
        }
    }
    
    
    //snap to the nearest snap point
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
                //this child is the minigame picker trigger
                snapPoint.GetChild(0).gameObject.SetActive(true);
            }
           
        }

        if (closestSnapPoint != null)
        { 
            item.transform.position = closestSnapPoint.position + new Vector3(0, 0.3f, 0);
        }
    }
    
    public void SelectItem()
    {
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (newitem != null)
        {
            Destroy(newitem.gameObject);
        }

        foreach (var grave in graves)
        {
            if (grave.name == buttonName)
            {
                item = ((ChooseGrave) grave).graveObject;
            }
        }
        
        newitem = null;
        newitem = Instantiate(item, parentItem.transform.position, Quaternion.identity);
        newitem.transform.SetParent(parentItem.transform);
        newitem.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ToHeadstones()
    {
        //check to see if graves are correct,  if so, add a point
        newitem = null;
        TallyUp();
        graveGroupButtons.SetActive(false);
        headstoneGroupButtons.SetActive(true);
    }

    public void TallyUp()
    {
        if (buttonName == choosenGrave)
        {
            ScoreManager.instance.score += 1;
            score.text = "SoulPoints: " + ScoreManager.instance.score;
            Debug.Log(ScoreManager.instance.score);
            
        }

    }
}
