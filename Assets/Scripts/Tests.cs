using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tests : MonoBehaviour
{
    private Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
      inventory = new Inventory(150);
      
      TestInventoryFunctionality();
    }

    private void TestCreateItem()
    {
        Debug.Log("============== Testing creation of items =============");
        Item i = new AccessItem("Key of doom", 10, 1);
        DebugItem(i);
        
        Item j = new BonusItem("Potato of the gods", 2, 100);
        DebugItem(j);
    }

    private void TestInventoryFunctionality()
    {
        Debug.Log("============== Testing inventory functionality =============");
        Item i = new AccessItem("Key of doom", 10, 1);
        Item j = new BonusItem("Potato of the gods", 50, 50);
        Item k = new BonusItem("Globe of eternal sunshine", 50, 100);

        if (inventory.AddItem(i))
        {
            Debug.Log("Added " + i.GetName() + " to the inventory");
        }
        else
        {
            Debug.Log("Failed to add " + i.GetName() + " to the inventory");
        }
        
        if (inventory.AddItem(j))
        {
            Debug.Log("Added " + j.GetName() + " to the inventory");
        }
        else
        {
            Debug.Log("Failed to add " + j.GetName() + " to the inventory");
        }
        
        if (inventory.AddItem(k))
        {
            Debug.Log("Added " + k.GetName() + " to the inventory");
        }
        else
        {
            Debug.Log("Failed to add " + k.GetName() + " to the inventory");
        }
        
        inventory.DebugInventory();

        if (inventory.CanOpenDoor(1))
        {
            Debug.Log("Door 1 can be opened.");
        }
        else
        {
            Debug.Log("Door 1 can NOT be opened.");
        }
        
        if (inventory.CanOpenDoor(2))
        {
            Debug.Log("Door 2 can be opened.");
        }
        else
        {
            Debug.Log("Door 2 can NOT be opened.");
        }
        
        if (inventory.HasItem(i))
        {
            Debug.Log("Inventory has Key of doom");
        }
        else
        {
            Debug.Log("Key of doom not in inventory");
        }

        if (inventory.RemoveItem(i))
        {
            Debug.Log("Key Removed");
        }
        else
        {
            Debug.Log("Key was not removed");
        }
        
        if (inventory.CanOpenDoor(1))
        {
            Debug.Log("Door 1 can be opened.");
        }
        else
        {
            Debug.Log("Door 1 can NOT be opened.");
        }

        if (inventory.HasItem(i))
        {
            Debug.Log("Inventory has Key of doom");
        }
        else
        {
            Debug.Log("Key of doom not in inventory");
        }
        
    }

    

    private void DebugItem(Item i)
    {
        string itemInfo = "The item: " + i.GetName() + " weighs " + i.GetWeight() + "Kg";
        string extraInfo = "";
        
        if (i is AccessItem)
        {
            AccessItem ai = (AccessItem) i;
            extraInfo = " and opens door: " + ai.GetDoorId();
        }
        else if (i is BonusItem)
        {
            BonusItem bi = (BonusItem) i;
            extraInfo = " and give you: " + bi.GetPoints() + " points";
        }
        
        Debug.Log(itemInfo + extraInfo);
    }
}
