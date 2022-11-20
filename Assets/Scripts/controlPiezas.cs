using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlPiezas : MonoBehaviour
{
    GameObject objetoEnColision;
    public Button btnRecoger;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Pieza(Clone)")
        {
            //Debug.Log("Choca con pieza");
            btnRecoger.interactable = true;
            objetoEnColision = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Pieza(Clone)")
        {
            //Debug.Log("Choca con pieza");
            btnRecoger.interactable = false;

        }
    }
    public void destruirPieza()
    {
        Destroy(objetoEnColision);
        btnRecoger.interactable = false;
    }
}
