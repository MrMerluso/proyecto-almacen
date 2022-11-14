using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    
    [SerializeField]
    public List<ClientSpawnpoint> Spawnpoints;
    public Client Client;


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
                
                return;
            }
        }
    }

    

}
