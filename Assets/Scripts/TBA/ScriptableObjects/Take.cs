using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Text Adventure/Input Actions/Take")]
public class Take : InputAction {
    public override void RespondToInput(GameController gc, string[] separatedInputWords)
    {
        var takeDict = gc.interactableItems.Take(separatedInputWords);
        if (takeDict != null)
        {
            gc.logStringWithReturn(gc.TestVerDictWithNoun(takeDict, separatedInputWords[0], separatedInputWords[1]));
        }
    }
}
