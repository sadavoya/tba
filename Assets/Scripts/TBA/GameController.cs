using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text DisplayText;
    public InputAction[] InputActions_Setup;

    [HideInInspector]
    public RoomNavigation roomNavigation;
    [HideInInspector]
    public InteractableItems interactableItems;
    [HideInInspector]
    public List<string> interactiveDescriptionsInRoom = new List<string>();
    [HideInInspector]
    public Dictionary<string, InputAction> InputActions = new Dictionary<string, InputAction>();

    private List<string> actionLog = new List<string>();

    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
        interactableItems = GetComponent<InteractableItems>();
    }

    // Use this for initialization
    void Start () {
        InitInputActionsDict();
        DisplayRoomText();
        DisplayLogText();
	}

    private void InitInputActionsDict()
    {
        foreach (var action in InputActions_Setup)
        {
            InputActions.Add(action.Keyword, action);
        }
    }

    public void DisplayRoomText()
    {
        clearCollectionsForNewRoom();

        unpackRoom();

        string joinInteractiveStringsInRoom = string.Join("\n", interactiveDescriptionsInRoom.ToArray());

        StringBuilder sb = new StringBuilder();

        sb.AppendLine(this.roomNavigation.CurrentRoom.Description);
        sb.AppendLine(joinInteractiveStringsInRoom);

        logStringWithReturn(sb.ToString());
    }

    public void DisplayLogText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        DisplayText.text = logAsText;
    }
    public void logStringWithReturn(string toAdd)
    {
        actionLog.Add(toAdd + "\n");
    }
    void unpackRoom()
    {
        PrepareObjectsToTakeOrExamine(roomNavigation.CurrentRoom);
        roomNavigation.unpackExitsInRoom();
    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.Interactables.Length; i++)
        {
            string descNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);

            if (descNotInInventory != null)
            {
                interactiveDescriptionsInRoom.Add(descNotInInventory);
            }

            var interactable = currentRoom.Interactables[i];
            for (int j = 0; j < interactable.Interactions.Length; j++)
            {
                var interaction = interactable.Interactions[j];
                if (interaction.Action.Keyword == "examine")
                {
                    interactableItems.examineDict.Add(interactable.Noun, interaction.Response);
                }
            }
        }

    }

    public string TestVerDictWithNoun(Dictionary<string, string> verbDict, string verb, string noun)
    {
        if (verbDict.ContainsKey(noun))
        {
            return verbDict[noun];
        }
        return string.Format("You can't {0} {1}.", verb, noun);
    }
    void clearCollectionsForNewRoom()
    {
        interactableItems.ClearCollections();
        interactiveDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }
}
