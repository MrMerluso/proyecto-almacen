using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public bool equiped = false;
    public static PlayerInfo Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }


    public bool SetItem(PickupController pc)
    {
        if (equiped)
        {
            return false;
        }
        equiped = true;
        return true;
    }
    public void DropItem()
    {
        equiped = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
