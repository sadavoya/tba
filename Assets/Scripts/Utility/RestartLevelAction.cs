using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RestartLevelAction : Utility.Action {
    public override void DoAction()
    {
        Utility.Useful.RestartCurrentLevel();
    }
}
