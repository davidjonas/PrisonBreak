using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class Item
{
    //Properties
    private string name;
    private float weight;

    //Constructor
    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }
    
    //Methods
    public string GetName()
    {
        return name;
    }

    public float GetWeight()
    {
        return weight;
    }
}
