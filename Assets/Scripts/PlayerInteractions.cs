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

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpDistance, Color.red);

        // Recoger item
        if (Input.GetKey(KeyCode.E) && !hasItem)
        {
            // Si se encuentra un objeto con el cual se puede interactuar
            if (Physics.Raycast(interactionRay, out hit, pickUpDistance, interactableLayerMask))
            {
                Debug.Log(hit.collider.gameObject.name);
                pickupController = hit.transform.GetComponent<PickupController>();
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

        //
        if (Input.GetKey(KeyCode.F) && hasItem)
        {
            // Si se encuentra un objeto con el cual se puede interactuar
            if (Physics.Raycast(interactionRay, out hit, pickUpDistance, itemFramesLayerMask))
            {
                Debug.Log(hit.collider.gameObject.name);
                var itemFrame = hit.transform;
                pickupController.Place(itemFrame);
                hasItem = false;
                pickupController = null;
            }
        }
    }
}
