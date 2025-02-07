using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    public GameObject item;
    public float offset = 3f;
    private GameObject newitem;

    public Camera TopDownCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newitem != null)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = offset;
            newitem.transform.position = TopDownCamera.ScreenToWorldPoint(pos);
        }
    }
    
    public void SelectItem()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 worldPos = TopDownCamera.ScreenToWorldPoint(mousePos);
        Instantiate(item, worldPos, Quaternion.identity);
        newitem = item;
    }
}
