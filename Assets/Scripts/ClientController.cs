using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientController : MonoBehaviour
{
    public string pedido;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected" + collision.gameObject.GetComponent<ItemDetail>().ProductName);
        //collision.gameObject.GetComponent<ItemDetail>().ProductName;
        
    }

    public void TrySpawnClient(string pedido)
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            this.pedido = pedido;
        }
    }
}
