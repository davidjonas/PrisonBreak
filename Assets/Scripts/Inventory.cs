using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private float weight=0;
    public float MaximumWeight = 100;

    public bool AddItem(Item i)
    {
        if (weight + i.GetWeight() <= MaximumWeight)
        {
            items.Add(i);
            weight += i.GetWeight();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveItem(Item i)
    {
        bool success = items.Remove(i);

        if (success)
        {
            weight -= i.GetWeight();
        }

        return success;
    }

    public bool HasItem(Item i)
    {
        return items.Contains(i);
    }

    public bool CanOpenDoor(int id)
    {
        bool result = false;

        foreach (Item item in items)
        {
            if (item is AccessItem)
            {
                if (((AccessItem) item).OpensDoor(id))
                {
                    result = true;
                }
            }
        }

        return result;
    }

    public int Count()
    {
        return items.Count;
    }

    public float GetCurrentWeight()
    {
        return weight;
    }
    
    public void DebugInventory()
    {
        Debug.Log("Inventory has " + Count() + " items");
        Debug.Log("Total weight: " + GetCurrentWeight());

        foreach (Item item in items)
        {
            Debug.Log(item.GetName() + "-----" + item.GetWeight() + "Kg");
        }
    }
}
