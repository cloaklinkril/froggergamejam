using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public static EventScript current;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }
    public event Action onGoalReached;
    public void GoalReached()
    {
        if (onGoalReached != null)
        {
            onGoalReached();
        }
    }
    public event Action onGameWon;
    public void GameWon()
    {
        if (onGameWon != null)
        {
            onGameWon();
        }
    }
    public event Action onPlayerDrown;
    public void PlayerDrown()
    {
        if (onPlayerDrown != null)
        {
            onPlayerDrown();
        }
    }
    public event Action onPlayerRunOver;
    public void PlayerRunOver()
    {
        if (onPlayerRunOver != null)
        {
            onPlayerRunOver();
        }
    }
    public event Action onRespawnAfterDeath;
    public void RespawnAfterDeath()
    {
        if (onRespawnAfterDeath != null)
        {
            onRespawnAfterDeath();
        }
    }
}
