using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVehicle : MonoBehaviour
{
 
    [SerializeField] Transform mark;

    UnityEngine.AI.NavMeshAgent agent;
    public KeyCode moveUp;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }
    public void SetMovOrigen(Vector3 origen)
    {
        agent.SetDestination(origen);
    }

    public void ComenzarMov(){
         agent.SetDestination(mark.position);

    }
}
