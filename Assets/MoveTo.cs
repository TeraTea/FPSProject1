using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //assign the variable 'agent' to the component on this gameObject.
        agent = this.GetComponent<NavMeshAgent>();
        // tell the navMeshAgent component to move to the target's position
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;        
    }
}
