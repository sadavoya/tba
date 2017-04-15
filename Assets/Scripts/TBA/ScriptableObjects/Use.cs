using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text Adventure/Input Actions/Use")]
public class Use : InputAction {
    public override void RespondToInput(GameController gc, string[] separatedInputWords)
    {
        gc.interactableItems.UseItem(separatedInputWords);
    }
}
