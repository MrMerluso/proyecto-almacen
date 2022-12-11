using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientNavigation : MonoBehaviour
{
    [SerializeField]
    private Transform clientDestination;
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject client;
    private GameObject player;

    private bool onDestination = false;

    private void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update(){
        navMeshAgent.destination = clientDestination.position;
        if (Vector3.Distance(clientDestination.position, transform.position) < 2.5)
        {
            onDestination = true;
        }
        if (onDestination)
        {
            client.transform.LookAt(player.transform.position);
        }
        
    }

    public void SetDestination(Transform destination)
    {
        clientDestination = destination;
        client.transform.LookAt(destination.position);
    }

    
}
