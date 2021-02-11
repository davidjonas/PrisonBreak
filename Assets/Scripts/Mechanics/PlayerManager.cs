using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight=100;
    public Transform directionSetter;
    
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.2f, directionSetter.forward, out hit, 2))
            {
                IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                if (i != null)
                {
                    i.Action(this);
                }
            }
        }
        
        //Temporary code to test dropping
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropItem("Key of Doom");
        }
    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);

        if (i != null)
        {
            inventory.RemoveItem(i);
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
        }
        GameManager.Instance.TriggerInventoryUIUpdate();
    }
    
    public bool AddItem(Item i)
    {
        bool success = inventory.AddItem(i);
        if (success)
        {
            GameManager.Instance.TriggerInventoryUIUpdate();
        }
        return success;
        
    }

    public bool CanOpenDoor(int id)
    {
        return inventory.CanOpenDoor(id);
    }

    public string[] GetItemNames()
    {
        return inventory.GetItemNames();
    }
     
}
