using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Yarn.Unity;


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
    public bool snapped = false;
    public List<Transform> snapPoints = new List<Transform>();
    public float pickUpRange = 10f; // Range within which the player can pick up objects
    // Start is called before the first frame update
    void Start()
    {
        


    }
    [YarnCommand("selectGraves")]
    public void selectGraves()
    {
        //choose a grave based on choosen quest manager townsfolk
        choosenGrave = QuestManager.instance.townsfolkChoosen.Grave;
        //choosenGrave = ((ChooseGrave) graves[UnityEngine.Random.Range(0, graves.Count)]).name;
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
                if (snapped)
                {
                    newitem.GetComponent<Rigidbody>().isKinematic = false;
                    newitem.transform.SetParent(null);
                    snapped = false;
                    SnapToNearestPoint(newitem);
                    newitem.GetComponent<Rigidbody>().isKinematic = true;
                }

            }
        }
        
        //if you press q it will delete the object
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (newitem != null)
            {
                Destroy(newitem.gameObject);
                snapped = false;
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
    
    //put item on your mouse
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
        //set the position of the item to the parent item and make it kinematic
        newitem.transform.SetParent(parentItem.transform);
        newitem.GetComponent<Rigidbody>().isKinematic = true;
        snapped = true;
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
            ScoreManager.score += 1;
            score.text = "SoulPoints: " + ScoreManager.score;
            Debug.Log(ScoreManager.score);
            
        }

    }
    
}
