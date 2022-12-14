using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDespawnTrigger : MonoBehaviour
{
    [SerializeField]
    private ClientManager clientManager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Client")
        {
            
            Client client = other.gameObject.GetComponent<Client>();
            if (client != null && client.isReturning)
            {
                Destroy(client.gameObject);
            }
        }
    }

}
