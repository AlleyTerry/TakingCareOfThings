using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;

    void Update()
      {
          pos = Input.mousePosition;
          pos.z = offset;
          
          transform.position = new Vector3(Mathf.Round(pos.x),
              Mathf.Round(pos.y),
              Mathf.Round(pos.z));
          
          //transform.position = Camera.main.ScreenToWorldPoint(pos);
          
          
          //transform.position = Vector3(Mathf.Round(currentPos.x),
             // Mathf.Round(currentPos.y),
             // Mathf.Round(currentPos.z));
      }
}
