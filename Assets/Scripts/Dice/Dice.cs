using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Side[] sides = null;

    public Side Roll()
    {
        return sides[Random.Range(0, sides.Length)];
    }
}
