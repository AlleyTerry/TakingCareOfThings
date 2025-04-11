using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTIp : MonoBehaviour
{
    // Start is called before the first frame update
    public string message;
    
    public void OnMouseEnter()
    {
        // Show tooltip with the message
        ToolTipManager.instance.ShowToolTip(message);
    }
    public void OnMouseExit()
    {
        // Hide tooltip
        ToolTipManager.instance.HideToolTip();
    }
}
