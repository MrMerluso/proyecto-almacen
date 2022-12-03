using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    
    [SerializeField]
    public List<ClientSpawnpoint> Spawnpoints;
    public Client Client;
    public MeshRenderer meshRenderer;


    public bool CheckAvalibleSpawns()
    {
        foreach (ClientSpawnpoint spawn in Spawnpoints)
        {
            if (spawn.isAvailible)
            {
                return true;
            }
        }

        return false;
    }

    public void SpawnClient(OrderDetail OrderDetail)
    {
        // revisar si hay algun spawn disponible. Spawnear cliente si 
        // se encuentra espacio
        foreach (ClientSpawnpoint spawn in Spawnpoints)
        {
            if (spawn.isAvailible)
            {
                Client ClientInstance = Instantiate(Client);
                ClientInstance.OrderDetail = OrderDetail;
                ClientInstance.Spawnpoint = spawn;
                ClientInstance.transform.position = spawn.transform.position;
                ClientInstance.isSpawned = true;
                spawn.isAvailible = false;
                if (OrderDetail._orderData._orderProduct == "Hamburguesa")
                {
                    ClientInstance.gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color32(139, 69, 19,255);
                }
                if (OrderDetail._orderData._orderProduct == "Queso")
                {
                    ClientInstance.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
                }
                if (OrderDetail._orderData._orderProduct == "Completo")
                {
                    ClientInstance.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                }
                return;
            }
        }
    }

    

}
