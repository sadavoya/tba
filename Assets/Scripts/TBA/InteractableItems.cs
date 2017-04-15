using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {
    public Dictionary<string, string> examineDict = new Dictionary<string, string>();
    public Dictionary<string, string> takeDict = new Dictionary<string, string>();

    [HideInInspector]
    public List<string> nounsInRoom = new List<string>();

    private GameController GC;
    private List<string> nounsInInventory = new List<string>();

    void Awake()
    {
        GC = GetComponent<GameController>();
    }

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
    public Dictionary<string, string> Take (string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];
        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            nounsInRoom.Remove(noun);
            return takeDict;
        }
        else
        {
            GC.logStringWithReturn("There is no " + noun + " to take!");
            return null;
        }
    }
    public void ClearCollections()
    {
        examineDict.Clear();
        takeDict.Clear();
        nounsInRoom.Clear();
    }
}
