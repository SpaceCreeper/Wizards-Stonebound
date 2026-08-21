using UnityEngine;

public class KillObjective : Objective
{
    public GameObject targetEnemy;

    protected override bool CompletionCheck()
    {
        return targetEnemy == null;
    }
}