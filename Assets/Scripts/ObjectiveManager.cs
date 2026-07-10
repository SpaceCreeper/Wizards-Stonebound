using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public List<Objective> objectivesList = new List<Objective>();
    private int currentObjectiveIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objectivesList.Count == 0) return;

        for (int i = 0; i < objectivesList.Count; i++)
        {
            objectivesList[i].enabled = false;
        }

        objectivesList[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjectiveIndex >= objectivesList.Count) return;

        if (objectivesList[currentObjectiveIndex].IsCompleted)
        {
            objectivesList[currentObjectiveIndex].enabled = false;

            currentObjectiveIndex++;

            if (currentObjectiveIndex < objectivesList.Count)
            {
                objectivesList[currentObjectiveIndex].enabled = true;
                Debug.Log($"New Active Objective: {objectivesList[currentObjectiveIndex].Title}");
            }
        }
    }
}
