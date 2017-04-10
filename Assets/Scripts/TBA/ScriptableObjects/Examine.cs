using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text Adventure/Input Actions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameController gc, string[] separatedInputWords)
    {
        gc.logStringWithReturn(string.Format("You examine the {0}", separatedInputWords[1]));
    }
}
