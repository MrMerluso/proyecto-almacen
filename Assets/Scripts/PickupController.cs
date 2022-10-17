using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, itemContainer, cam, itemFrame;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public bool isPlaced;
    public static bool slotFull;

    // Start is called before the first frame update
    void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        else
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Recoger item cuando se apreta la tecla "E"
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
            PickUp();

        // Soltar item si esta equipado y se presiona la tecla "Q"
        if (equipped && Input.GetKeyDown(KeyCode.Q))
            Drop();

        if (equipped && Input.GetKeyDown(KeyCode.F) && !isPlaced)
            Place();
    }
    private void PickUp()
    {
        equipped = true;
        isPlaced = false;

        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
    }

    private void Place()
    {
        equipped = false;
        isPlaced = true;

        transform.SetParent(itemFrame);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }
}
