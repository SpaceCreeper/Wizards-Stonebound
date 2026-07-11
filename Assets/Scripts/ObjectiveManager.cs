using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private List<Objective> objectivesList = new List<Objective>();
    private int currentObjectiveIndex = 0;

    public event Action<string, string> OnObjectiveChanged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objectivesList.Count == 0) return;

        foreach (var objective in objectivesList)
        {
            objective.enabled = false;
        }

        ActivateObjective(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjectiveIndex >= objectivesList.Count) return;

        if (objectivesList[currentObjectiveIndex].IsCompleted)
        {
            AdvanceObjective();

            if (currentObjectiveIndex < objectivesList.Count)
            {
                ActivateObjective(currentObjectiveIndex);
            }
        }
    }

    private void AdvanceObjective()
    {
        objectivesList[currentObjectiveIndex].enabled = false;
        currentObjectiveIndex++;
    }

    private void ActivateObjective(int index)
    {
        objectivesList[index].enabled = true;

        Debug.Log($"New Objective: {objectivesList[index].Title}");

        OnObjectiveChanged?.Invoke(
            objectivesList[index].Title,
            objectivesList[index].Description
        );
    }
}
