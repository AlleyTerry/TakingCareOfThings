using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;
public class HeadstoneSelect : MonoBehaviour
{
    public List<ScriptableObject> headstones = new List<ScriptableObject>();
    public GameObject item;
    public float offset = 3f;
    public GameObject newitem;
    public GameObject parentItem;
    public String buttonName;
    public GameObject headstoneGroupButtons;
    public GameObject flowerGroupButtons;
    public GameObject MiniGameManager;
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI orderText;

    
    public List<Transform> snapPoints = new List<Transform>();

    public Camera TopDownCamera;

    public String choosenHeadstone;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }
    [YarnCommand("selectHeadstone")]
    public void selectHeadstone()
    {
        //choose a random headstone from the headstone list
        // choosenHeadstone = ((ChooseHeadstone) headstones[UnityEngine.Random.Range(0, headstones.Count)]).name;
        choosenHeadstone = QuestManager.instance.townsfolkChoosen.Headstone;

        Debug.Log(choosenHeadstone);
        orderText.text = choosenHeadstone;
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

        foreach (var stone in headstones)
        {
            if (stone.name == buttonName)
            {
                item = ((ChooseHeadstone) stone).headstoneObject;
            }
        }
        
        newitem = null;
        newitem = Instantiate(item, parentItem.transform.position, Quaternion.identity);
        newitem.transform.SetParent(parentItem.transform);
        newitem.GetComponent<Rigidbody>().isKinematic = true;
    }
    
    public void ToFlowers()
    {
        newitem = null;
        TallyUp();
        headstoneGroupButtons.SetActive(false);
        flowerGroupButtons.SetActive(true);
        
    }
    
    public void TallyUp()
    {
        if (buttonName == choosenHeadstone)
        {
           // ScoreManager.score += 1;
            score.text = "SoulPoints: " + ScoreManager.score;
            Debug.Log(ScoreManager.score);
        }

    }
}
