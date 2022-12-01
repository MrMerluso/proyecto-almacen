using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{

    public ShopManager ShopManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShopManager.Show();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ShopManager.Hide();
        }
            
    }
}
