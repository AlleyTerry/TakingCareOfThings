using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;


public class FlowerSelect2 : MonoBehaviour
{
 
    public List<ScriptableObject> flowers = new List<ScriptableObject>();
    public GameObject item;
    public float offset = 3f;
    public GameObject newitem;
    public GameObject parentItem;
    public String buttonName;
    public int flowerCount;
    public GameObject flowerButtons;
    public GameObject DoneButtion;
    public TMPro.TextMeshProUGUI finalTxt;
    public GameObject orderButtions;

    public GameObject backButton;
    // public static MiniGameManager instance;

    public String choosenFlower1;
    public String choosenFlower2;

    public Camera TopDownCamera;
    
    public List<Transform> snapPoints = new List<Transform>();
    public GameObject MiniGameManager;
    public TMPro.TextMeshProUGUI orderText;
    public TMPro.TextMeshProUGUI orderText2;

    public bool firstTime = true;
    
    public GameObject flower1;
    public GameObject flower2;
    public Transform closestSnapPoint = null;
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

                    SnapToNearestPoint(newitem);
                    newitem.GetComponent<Rigidbody>().isKinematic = false;
                    newitem.transform.SetParent(null);
                    newitem.GetComponent<Rigidbody>().isKinematic = true;
             
                
            }
        }
        //if you press q it will delete the object
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
                if (flower1 != null && flower2 == null)
                {
                    Destroy(flower1);
                }
                else
                {
                    if (flower1 != null && flower2 != null)
                    {
                        Destroy(flower2);
                    }
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
    public void ToEnd()
    {
        newitem = null;
        TallyUp2();
        //DoneButtion.SetActive(false);
        flowerButtons.SetActive(false);
        backButton.SetActive(true);
        orderButtions.SetActive(false);
        
        finalTxt.text ="You got " + ScoreManager.score + " soul points!";

        if (firstTime)
        {
            //play the tutorial dialogue
            FindObjectOfType<DialogueRunner>().StartDialogue("FlowerEnd");
            firstTime = false;
        }
        
        
    }
    public void TallyUp1()
    {
        if (buttonName == choosenFlower1 && flowerCount == 0)
        {
            ScoreManager.score += 1;
            Debug.Log(ScoreManager.score);
            flowerCount += 1;
            
        }

    }
    
    public void TallyUp2()
    {
        if (buttonName == choosenFlower2 )
        {
            ScoreManager.score += 1;
            Debug.Log(ScoreManager.score);
            //ToEnd();
        }

    }
    
}
