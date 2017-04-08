using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Text Adventure/Input Actions/Go")]
public class Go : InputAction {
    public override void RespondToInput(GameController gc, string[] separatedInputWords)
    {
        gc.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }
}
