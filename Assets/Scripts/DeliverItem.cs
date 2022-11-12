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
            //aqu� debe ir lo que va hacer la funci�n, para que se haga una vez
            /*if (!activated)
            {
                activated = true;
                Destroy(other.gameObject);
                activated = false;
                //enviar que ya se realiz� la orden
                //_isServed = true
            }*/
            if(item != null)
            {
                OrderManager.CheckOrder(item.ProductName);
                Destroy(item.gameObject);
            }
        }
    }


}

