using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public Transform holdPos; // Position where the object will be held

    public float throwForce = 500f; // Force at which the object is thrown
    public float pickUpRange = 5f; // Range within which the player can pick up objects
    private float rotationSensitivity = 1f; // Sensitivity for rotating the object
    private GameObject heldObj; // The object currently being held
    private Rigidbody heldObjRb; // Rigidbody of the held object
    private bool canDrop = true; // Flag to prevent dropping/throwing while rotating
    private int LayerNumber; // Layer index for the held object

    // Reference to script which includes mouse movement of player (looking around)
    // We want to disable the player looking around when rotating the object
    // Example below 
    // MouseLookScript mouseLookScript;

    void Start()
    {
        // Get the layer index for the hold layer
        LayerNumber = LayerMask.NameToLayer("holdLayer");

        // mouseLookScript = player.GetComponent<MouseLookScript>();
    }

    void Update()
    {
        // Check if the pick up/drop key is pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null) // If not holding anything
            {
                // Perform a raycast to check if the player is looking at an object within pick up range
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    Debug.Log(hit.transform);
                    // Check if the object has the "canPickUp" tag
                    if (hit.transform.gameObject.tag == "canPickUp")
                    {
                        // Pick up the object
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if (canDrop == true)
                {
                    // Prevent object from clipping through walls
                    StopClipping();
                    // Drop the object
                    DropObject();
                }
            }
        }

        if (heldObj != null) // If holding an object
        {
            // Keep the object at the hold position
            MoveObject();
            // Rotate the object if needed
            RotateObject();
            // Check if the throw key is pressed
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true)
            {
                // Prevent object from clipping through walls
                StopClipping();
                // Throw the object
                ThrowObject();
            }
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        // Check if the object has a Rigidbody
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            // Assign the held object and its Rigidbody
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            // Make the Rigidbody kinematic
            heldObjRb.isKinematic = true;
            // Parent the object to the hold position
            heldObjRb.transform.parent = holdPos.transform;
            // Change the object's layer to the hold layer
            heldObj.layer = LayerNumber;
            // Ignore collision between the object and the player
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        // Re-enable collision between the object and the player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        // Change the object's layer back to the default layer
        heldObj.layer = 0;
        // Make the Rigidbody non-kinematic
        heldObjRb.isKinematic = false;
        // Unparent the object
        heldObj.transform.parent = null;
        // Clear the held object reference
        heldObj = null;
    }

    void MoveObject()
    {
        // Keep the object at the hold position
        heldObj.transform.position = holdPos.transform.position;
    }

    void RotateObject()
    {
        // Check if the rotate key is held down
        if (Input.GetKey(KeyCode.R))
        {
            // Prevent dropping/throwing while rotating
            canDrop = false;

            // Disable player looking around
            // mouseLookScript.verticalSensitivity = 0f;
            // mouseLookScript.lateralSensitivity = 0f;

            // Rotate the object based on mouse movement
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
            // Re-enable player looking around
            // mouseLookScript.verticalSensitivity = originalvalue;
            // mouseLookScript.lateralSensitivity = originalvalue;
            canDrop = true;
        }
    }

    void ThrowObject()
    {
        // Re-enable collision between the object and the player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        // Change the object's layer back to the default layer
        heldObj.layer = 0;
        // Make the Rigidbody non-kinematic
        heldObjRb.isKinematic = false;
        // Unparent the object
        heldObj.transform.parent = null;
        // Add force to the object to throw it
        heldObjRb.AddForce(transform.forward * throwForce);
        // Clear the held object reference
        heldObj = null;
    }

    void StopClipping()
    {
        // Calculate the distance from the hold position to the camera
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
        // Perform a raycast to check for collisions within the clip range
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        // If more than one collider is hit, reposition the object to prevent clipping
        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        }
    }
}