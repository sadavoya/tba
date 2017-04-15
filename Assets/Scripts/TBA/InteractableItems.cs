using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {
    public List<Interactable> useableItemList;
    public Dictionary<string, string> examineDict = new Dictionary<string, string>();
    public Dictionary<string, string> takeDict = new Dictionary<string, string>();
    public Dictionary<string, ActionResponse> useDict = new Dictionary<string, ActionResponse>();

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
            AddActionResponsesToUseDict();
            nounsInRoom.Remove(noun);
            return takeDict;
        }
        else
        {
            GC.logStringWithReturn("There is no " + noun + " to take!");
            return null;
        }
    }
    public void DisplayInventory()
    {
        GC.logStringWithReturn("You look in your backpack. Inside you have:");
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            GC.logStringWithReturn(nounsInInventory[i]);
        }
    }
    public void AddActionResponsesToUseDict()
    {
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            var noun = nounsInInventory[i];
            var interactable = GetInteractableObjectFromUsableList(noun);

            if (interactable == null)
                continue;
            for (int j = 0; j < interactable.Interactions.Length; j++)
            {
                var interaction = interactable.Interactions[j];
                if (interaction.ActionResponse == null)
                    continue;
                if (!useDict.ContainsKey(noun))
                {
                    useDict.Add(noun, interaction.ActionResponse);
                }
            }
        }
    }
    private Interactable GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < useableItemList.Count; i++)
        {
            if (useableItemList[i].Noun == noun)
            {
                return useableItemList[i];
            }
        }
        return null;
    }
    public void UseItem(string[] separatedInputwords)
    {
        string nounToUse = separatedInputwords[1];
        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDict.ContainsKey(nounToUse))
            {
                bool actionResult = useDict[nounToUse].DoActionResponse(GC);
                if (!actionResult)
                {
                    GC.logStringWithReturn("Hmm. Nothing happens.");
                }
            }
            else
            {
                GC.logStringWithReturn("You can't use " + nounToUse);
            }
        }
        else
        {
            GC.logStringWithReturn("There is no " + nounToUse + " in your inventory.");
        }
    }
    public void ClearCollections()
    {
        examineDict.Clear();
        takeDict.Clear();
        nounsInRoom.Clear();
    }
}
