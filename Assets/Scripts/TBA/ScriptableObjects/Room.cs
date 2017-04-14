using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"Text Adventure/Room")]
public class Room : ScriptableObject {
    [TextArea]
    public string Description;
    public string Name;
    public Exit[] Exits;
    public Interactable[] Interactables;
}
