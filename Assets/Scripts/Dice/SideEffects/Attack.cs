using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "DungeonDices/SideEffects/Attack", order = 0)]
public class Attack : SideEffect
{
    public override void Activate(int value, GameObject target)
    {
        target.GetComponent<Health>().Damage(value);
    }
        
    // 아래는 전투 주사위만 사용
    public override bool isSelf()
    {
        return false;
    }

    public override string GetCombatMessage(string target, int value)
    {
        return target + "에게 " + value + " 데미지를 입혔다!";
    }
}
