using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientNavigation : MonoBehaviour
{
    [SerializeField]
    private Transform clientDestination;
    private NavMeshAgent navMeshAgent;

    private void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update(){
        navMeshAgent.destination = clientDestination.position;
    }

    
}
