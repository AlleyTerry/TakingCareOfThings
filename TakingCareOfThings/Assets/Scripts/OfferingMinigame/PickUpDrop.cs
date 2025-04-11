using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    public float pickUpRange = 10f; // Range within which the player can pick up objects
    private GameObject heldObject; // The object currently being held
    private Rigidbody heldObjectRb; // Rigidbody of the held object
    public float offset = 3f; // Offset for the object to follow the mouse

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        // Make the held object follow the mouse
        if (heldObject != null)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = offset;
            heldObject.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
    }

    void TryPickUpObject()
    {
        RaycastHit hit;
        // Perform a raycast to check if the player is looking at an object within pick up range
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, pickUpRange))
        {
            // Check if the object has the "PickUp" tag
            if (hit.transform.CompareTag("PickUp") || hit.transform.CompareTag("leaf") || hit.transform.CompareTag("body") || hit.transform.CompareTag("plastic"))
            {
                PickUpObject(hit.transform.gameObject);
            }
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        // Check if the object has a Rigidbody
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            // Assign the held object and its Rigidbody
            heldObject = pickUpObj;
            heldObjectRb = pickUpObj.GetComponent<Rigidbody>();
            // Make the Rigidbody kinematic
            heldObjectRb.isKinematic = true;
        }
    }

    void DropObject()
    {
        // Make the Rigidbody non-kinematic
        heldObjectRb.isKinematic = false;
        // Clear the held object reference
        heldObject = null;
    }
}