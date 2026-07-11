using System;
using UnityEngine;

public abstract class Objective : MonoBehaviour, IObjective
{
    [SerializeField] protected string title;
    [SerializeField] protected string description;
    [SerializeField] private bool isCompleted;

    public string Title => title;
    public string Description => description;
    public bool IsCompleted
    {
        get => isCompleted;
        protected set => isCompleted = value;
    }

    protected abstract bool CompletionCheck();

    // REMOVE IF UNNECESSARY (FOR DEBUG ONLY)
    protected virtual void CompleteObjective()
    {
        Debug.Log($"Objective Completed: {Title}");
    }

    protected virtual void Update()
    {
        if (isCompleted) return; 

        if (CompletionCheck())
        {
            IsCompleted = true;
            CompleteObjective();
        }
    }
}