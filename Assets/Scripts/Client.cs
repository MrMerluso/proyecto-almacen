using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Client : MonoBehaviour
{
    /* 
        Esto maneja cuando a un cliente se le arroja un objeto que se 
        le puede vender
     */


    // Esto es solamente la punta del mounstruo de spagetti en lo que se
    // va a convertir este proyecto y no estoy listo para lo que se viene

    // Necesito esto para saber cuando expira la orden y asi borrar el cliente
    public OrderDetail OrderDetail;
    // Necesito esto para poner el spawnpoint como disponible cuando se 
    // termine el pedido
    public ClientSpawnpoint Spawnpoint;
    private ClientNavigation navigation;

    public AudioSource purchaseSound;
    
    public bool isSpawned = false;

    void Awake()
    {
        this.navigation = GetComponent<ClientNavigation>();
        this.purchaseSound = GameObject.FindGameObjectWithTag("PurchaseSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        // si la orden expira, eliminar cliente y habilitar spawn
        if (OrderDetail != null && OrderDetail._isExpired)
        {
            Spawnpoint.isAvailible = true;
            OrderManager.currentWaveSize--;
            navigation.SetDestination(Spawnpoint.transform);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        // revisar si el objeto que le arrojaron coincide con el que 
        // está pidiendo
        if (collision.gameObject.tag == "Object")
        {            
            ItemDetail item = collision.gameObject.GetComponent<ItemDetail>();
            if (item.ProductName == OrderDetail._orderData._orderProduct)
            {
                OrderManager.CheckOrder(item);
                OrderManager.currentWaveSize--;
                purchaseSound.Play();
                Spawnpoint.isAvailible = true;
                navigation.SetDestination(Spawnpoint.transform);
            }
        }
    }






    

    
}
