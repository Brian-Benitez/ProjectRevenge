using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static DoorController instance; 

    [Header("All Doors in level")]
    public List<GameObject> AllDoorsInLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    /// <summary>
    /// Close all doors for battle.
    /// </summary>
    public void CloseAllDoorsInLevel()
    {
        foreach (GameObject Door in AllDoorsInLevel)
        {
            Door.SetActive(true);
        }
    }
    /// <summary>
    /// Open all doors after battle is done.
    /// </summary>
    public void OpenAllDoorsInLevel()
    {
        foreach (GameObject Door in AllDoorsInLevel)
        {
            Door.SetActive(false);
        }
    }
}
