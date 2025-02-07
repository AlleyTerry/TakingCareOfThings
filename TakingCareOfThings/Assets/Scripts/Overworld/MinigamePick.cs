using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MinigamePick : MonoBehaviour
{
    
    public GameObject buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            buttons.SetActive(true);
        }
    }

    public void flower()
    {
        SceneManager.LoadScene(1);
        
    }
    
    public void leaves()
    {
        SceneManager.LoadScene(2);
    }
}
