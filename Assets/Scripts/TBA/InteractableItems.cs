using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {
    public Dictionary<string, string> examineDict = new Dictionary<string, string>();

    [HideInInspector]
    public List<string> nounsInRoom = new List<string>();

    private List<string> nounsInInventory = new List<string>();


    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        var objectInRoom = currentRoom.Interactables[i];
        if (!nounsInInventory.Contains(objectInRoom.Noun))
        {
            nounsInRoom.Add(objectInRoom.Noun);
            return objectInRoom.Description;
        }
        return null;
    }
}
