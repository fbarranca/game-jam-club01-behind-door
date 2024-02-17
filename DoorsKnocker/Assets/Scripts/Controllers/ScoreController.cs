using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreController
{
    private static int score = 0;

    public static void IncreaseScore()
    {
        score++;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }
}
