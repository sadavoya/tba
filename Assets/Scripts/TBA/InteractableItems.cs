using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {
    [HideInInspector]
    public List<string> nounsInRoom = new List<string>();

    private List<string> nounsInInventory = new List<string>();


    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        var interactable = currentRoom.Interactables[i];
        if (!nounsInInventory.Contains(interactable.Noun))
        {
            nounsInRoom.Add(interactable.Noun);
            return interactable.Description;
        }
        return null;
    }
}
