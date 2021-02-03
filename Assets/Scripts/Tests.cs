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

    public void TestCreateItem()
    {
        Item i = new Item("Key of doom", 10);
        Debug.Log("The item: "+ i.GetName() + " weighs " + i.GetWeight() + "Kg");
    }
}
