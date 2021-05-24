using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SideEffect", menuName = "DungeonDices/SideEffect", order = 0)]
public abstract class SideEffect : ScriptableObject
{
    public abstract void Activate(int value, GameObject target);
        
    // 아래는 전투 주사위만 사용
    public abstract bool isSelf(); 
    public abstract string GetCombatMessage(string target, int value);
}
