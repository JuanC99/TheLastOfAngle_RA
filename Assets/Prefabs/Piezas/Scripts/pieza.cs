using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieza : MonoBehaviour
{
    /*
    Button btnRecoger;
    private void Start()
    {
        btnRecoger = GameObject.FindGameObjectWithTag("btnRecoger").GetComponent<Button>();
        btnRecoger.onClick.AddListener(destruir);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            btnRecoger.interactable = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            btnRecoger.interactable = false;
        }
    }
    public void destruir()
    {
        Destroy(this);
    }
    */
    private void OnDestroy()
    {
        Debug.Log("Pieza destruida");
    }
}
