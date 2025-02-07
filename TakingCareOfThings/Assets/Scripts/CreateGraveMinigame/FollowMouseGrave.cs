using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseGrave : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;
    public Camera TopDownCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TopDownCamera.isActiveAndEnabled)
        {
            pos = Input.mousePosition;
            pos.z = offset;
            transform.position = TopDownCamera.ScreenToWorldPoint(pos);
        }
    }
}
