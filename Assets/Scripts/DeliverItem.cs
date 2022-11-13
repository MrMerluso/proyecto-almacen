using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverItem : MonoBehaviour
{
    private bool activated = false;


    private void OnTriggerEnter(Collider other)
    {
        //Si other colisiona y tiene el tag Object 
        if (other.tag == "Object")
        {
            ItemDetail item = other.gameObject.GetComponent<ItemDetail>(); 
            if(item != null)
            {
                OrderManager.CheckOrder(item.ProductName);
                Destroy(item.gameObject);
            }
        }
    }


}

