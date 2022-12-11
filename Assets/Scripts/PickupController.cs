using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, itemContainer, cam;

    public float dropForwardForce, dropUpwardForce;

    
    public bool isPlaced;

    // Start is called before the first frame update
    void Awake(){
        SetAttributes();
    }

    // Probablemente una forma horrible de hacer esto, pero es lo que se me ocurrio xd
    public void SetAttributes()
    {
        player = GameObject.FindWithTag("Player").transform;
        cam = GameObject.FindWithTag("MainCamera").transform;
        itemContainer = GameObject.FindWithTag("ItemHolder").transform;
    }

    public void PickUp()
    {
        if (!PlayerInfo.Instance.SetItem(this))
        {
            return;
        }
        
        isPlaced = false;

        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    public void Drop()
    {
        PlayerInfo.Instance.DropItem();
        

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
    }

    public void Place(Transform itemFrame)
    {
        PlayerInfo.Instance.DropItem();
        
        isPlaced = true;

        transform.SetParent(itemFrame);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }
}
