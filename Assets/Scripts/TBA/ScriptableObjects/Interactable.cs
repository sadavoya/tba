﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text Adventure/Interactable")]
public class Interactable : ScriptableObject {
    public string Noun = "name";
    [TextArea]
    public string Description = "Description in room";

    public Interaction[] Interactions;
}
