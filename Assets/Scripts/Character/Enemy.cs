using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string myName = null;
    public Dice currentDice = null;

    public int GetDamage()
    {
        return Random.Range(1, 7);
    }
}
