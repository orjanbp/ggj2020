using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    protected int score = 0;

    public void addScore (int amount)
    {
        score += amount;
    }

    public void deductScore (int amount)
    {
        score -= amount;
    }
}
