using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum CombatPhase
{
    StandBy, PlayerT, EnemyT, End
}

public class CombatManager : MonoBehaviour
{
    public CombatPhase combatPhase;
    [SerializeField] float waitTime = 0.5f;

    [SerializeField] TextMeshProUGUI combatText = null;

    Player player;
    Enemy enemy;

    void Start()
    {
        StandByCombat();
    }
    
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(combatPhase == CombatPhase.StandBy)
            {
                MoveToPlayerTurn();
            }

            if(combatPhase == CombatPhase.PlayerT)
            {
                StartCoroutine(HandlePlayerTurn());
            }
        }    
    }

    void StandByCombat()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();

        combatPhase = CombatPhase.StandBy;
        combatText.text = enemy.myName + "(이)가 나타났다!";
    }

    void MoveToPlayerTurn()
    {
        combatPhase = CombatPhase.PlayerT;
        combatText.text = "무엇을 할까?";
    }

    IEnumerator HandlePlayerTurn()
    {
        Side resultSide = player.currentDice.Roll();
        SideEffect currentSideEffect = resultSide.sideEffect;

        GameObject target;
        string targetName;
        if(currentSideEffect.isSelf()) 
        {
            target = player.gameObject;
            targetName = "당신";
        }
        else 
        {
            target = enemy.gameObject;
            targetName = enemy.myName;
        }

        currentSideEffect.Activate(resultSide.value, target);

        if(resultSide.sideType == SideType.Attack)
        {
            player.PlayAttackAnimation();
        }
        
        combatText.text = currentSideEffect.GetCombatMessage(targetName, resultSide.value);

        yield return new WaitForSeconds(waitTime);

        if(enemy.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            StartCoroutine(HandleCombatWin());
        }
        else
        {
            StartCoroutine(HandleEnemyTurn());
        }
    }

    IEnumerator HandleEnemyTurn()
    {
        combatPhase = CombatPhase.EnemyT;
        combatText.text = "적의 턴!";

        yield return new WaitForSeconds(waitTime);

        Side resultSide = enemy.currentDice.Roll();
        SideEffect currentSideEffect = resultSide.sideEffect;

        GameObject target;
        string targetName;
        if(currentSideEffect.isSelf()) 
        {
            target = enemy.gameObject;
            targetName = enemy.myName;
        }
        else 
        {
            target = player.gameObject;
            targetName = "당신";
        }

        currentSideEffect.Activate(resultSide.value, target);
        
        combatText.text = currentSideEffect.GetCombatMessage(targetName, resultSide.value);

        yield return new WaitForSeconds(waitTime);

        if(player.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            StartCoroutine(HandleCombatLose());
        }
        else
        {
            MoveToPlayerTurn();
        }
    } 

    IEnumerator HandleCombatWin()
    {
        combatPhase = CombatPhase.End;

        Destroy(enemy.gameObject);
        combatText.text = "전투에서 승리했다!";
        yield return null;
    }

    IEnumerator HandleCombatLose()
    {
        combatPhase = CombatPhase.End;

        player.PlayDieAnimation();
        combatText.text = "전투에서 패배했다...";
        yield return null;
    }
}
