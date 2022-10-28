using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public Transform playerCamera;
    public LayerMask interactableLayerMask, itemFramesLayerMask;
    private PickupController pickupController;

    public float pickUpDistance;
    private bool hasItem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // creamos un rayo para buscar objetos con los que se pueda interactuar
        RaycastHit hit;
        Ray interactionRay = new Ray(playerCamera.position, playerCamera.forward);
        //bool interactionRaycast = Physics.Raycast(interactionRay, out hit, pickUpDistance, interactableLayerMask);
        //bool itemFramesRaycast = Physics.Raycast(interactionRay, out hit, pickUpDistance, itemFramesLayerMask);

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpDistance, Color.red);

        // Recoger item
        if (Input.GetKeyDown(KeyCode.E) && !hasItem && Physics.Raycast(interactionRay, out hit, pickUpDistance, interactableLayerMask))
        {
            // Si se encuentra un objeto con el cual se puede interactuar
            
            
            Debug.Log(hit.collider.gameObject.name);
            pickupController = hit.transform.GetComponent<PickupController>();

            if (pickupController.isPlaced)
            {
                var boxItem = hit.collider.GetComponent<BoxController>().TakeFromBox();
                if (boxItem != null)
                {
                    pickupController = boxItem.GetComponent<PickupController>();
                    pickupController.PickUp();
                    hasItem = true;
                }
            }
            else
            {
                pickupController.PickUp();
                hasItem = true;
            }

 
        }

        // Soltar item
        if (Input.GetKey(KeyCode.Q) && hasItem)
        {
            pickupController.Drop();
            hasItem = false;
            pickupController = null;
        }

        // Poner item en un item frame (ponerlo en la repisa)
        if (Input.GetKey(KeyCode.F) && hasItem && Physics.Raycast(interactionRay, out hit, pickUpDistance, interactableLayerMask))
        {
            // Notar que estamos buscando el frame en una capa distinta a la de los items interactuables.
            // Esto fue lo que se me ocurrió en el momento y no estoy seguro de que sea la mejor solución,
            // pero por ahora funciona

            // To Do: Quizas haya que implementar un controlador para los item frames para
            // aplicar la logica de "desempaquetar" las cajas. Eso probablemente cambiaría esta lógica.
            Debug.Log(hit.collider.gameObject.name);
            var itemFrame = hit.transform;
            pickupController.Place(itemFrame);
            hasItem = false;
            pickupController = null;
            
        }
    }
}
