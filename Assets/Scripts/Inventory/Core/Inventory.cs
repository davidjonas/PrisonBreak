using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory
{
    private List<Item> items;
    private float weight;
    private float maximumWeight;

    public Inventory()
    {
        items = new List<Item>();
        weight = 0;
        maximumWeight = 100;
    }

    public Inventory(float maximumWeight) : this()
    {
        this.maximumWeight = maximumWeight;
    }

    public bool SetMaximumWeight(float maxWeight)
    {
        if (maxWeight >= weight)
        {
            maximumWeight = maxWeight;
            return true;
        }
 
        return false;
    }
    
    public bool AddItem(Item i)
    {
        if (weight + i.GetWeight() <= maximumWeight)
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

    public Item GetItemWithName(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == name)
            {
                return items[i];
            }
        }

        return null;
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

    public string [] GetItemNames()
    {
        string[] result = new string[items.Count];
        
        for (int i=0; i<items.Count; i++)
        {
            result[i] = items[i].GetName();
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
