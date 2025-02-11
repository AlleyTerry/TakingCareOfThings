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
          
          transform.position = transform.position = Camera.main.ScreenToWorldPoint(pos);
          
        
      }
}
