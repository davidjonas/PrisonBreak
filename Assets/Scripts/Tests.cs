using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      TestCreateItem();
    }

    private void TestCreateItem()
    {
        Item i = new AccessItem("Key of doom", 10, 1);
        DebugItem(i);
        
        Item j = new BonusItem("Potato of the gods", 2, 100);
        DebugItem(j);
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
