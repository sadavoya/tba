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
    public List<string> interactiveDescriptionsInRoom = new List<string>();
    [HideInInspector]
    public Dictionary<string, InputAction> InputActions = new Dictionary<string, InputAction>();

    private List<string> actionLog = new List<string>();

    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
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
        roomNavigation.unpackExitsInRoom();
    }
    void clearCollectionsForNewRoom()
    {
        interactiveDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }
}
