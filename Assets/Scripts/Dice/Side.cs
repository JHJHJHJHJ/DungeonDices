using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Side", menuName = "DungeonDices/Side", order = 0)]
public class Side : ScriptableObject
{
    public SideType sideType;
    public Sprite sideSprite;
    public int value;
    public string sideName;
    [TextArea] public string description;
    public SideEffect sideEffect;
}

public enum SideType
{
    Attack
}
