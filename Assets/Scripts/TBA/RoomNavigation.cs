using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {
    public Room CurrentRoom;
    private GameController GC;
    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

    void Awake()
    {
        this.GC = GetComponent<GameController>();
    }


    public void unpackExitsInRoom()
    {
        for (int i = 0; i < CurrentRoom.Exits.Length; i++)
        {
            var exit = CurrentRoom.Exits[i];

            exitDictionary.Add(exit.KeyString, exit.ValueRoom);
            GC.interactiveDescriptionsInRoom.Add(exit.Description);
        }
    }
    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            CurrentRoom = exitDictionary[directionNoun];
            GC.logStringWithReturn("You head " + directionNoun);
            GC.DisplayRoomText();
        }
        else
        {
            GC.logStringWithReturn("There is no path " + directionNoun);
        }
    }
    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
