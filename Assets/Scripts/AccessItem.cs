using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
    private int doorId;

    public AccessItem(string name, float weight, int door) : base(name, weight)
    {
        this.doorId = door;
    }

    public int GetDoorId()
    {
        return doorId;
    }
}
