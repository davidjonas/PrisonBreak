using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPickupItem(Pickup i)
    {
        if (!worldItems.ContainsKey(i.itemName))
        {
            worldItems.Add(i.itemName, i);
        }
        else
        {
            Debug.LogError("There is already an object with the name: " + i.itemName + ". There cannot be two items with the same name.");
        }
    }

    public void DropItem(string name, Vector3 position)
    {
        worldItems[name].Respawn(position);
    }
}
