using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    [Header("Players inventory")]
    public List<GameObject> Inventory;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    /// <summary>
    /// Adds object to player inventory.
    /// </summary>
    /// <param name="obj"></param>
    public void AddObjectToInventory(GameObject obj) => Inventory.Add(obj);

    /// <summary>
    /// Removes object from player inventory by looking at the name of obj
    /// </summary>
    /// <param name="nameOfObj"></param>
    public void RemoveObjectFromInventory(string nameOfObj)
    {
        foreach (GameObject obj in Inventory)
        {
            if(obj.name == nameOfObj)
            {
                Inventory.Remove(obj);
            }
        }
    }
}
