using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text Adventure/Action Responses/Change Room")]
public class ChangeRoomResponse : ActionResponse {
    public Room roomToChangeTo;
    public override bool DoActionResponse(GameController controller)
    {
        if (controller.roomNavigation.CurrentRoom.Name == requiredString)
        {
            controller.roomNavigation.CurrentRoom = roomToChangeTo;
            controller.DisplayRoomText();
            return true;
        }
        return false;
    }
}
