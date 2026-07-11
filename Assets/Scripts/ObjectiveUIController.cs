using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ObjectiveUIController : MonoBehaviour
{
    [SerializeField] private ObjectiveManager objectiveManager;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    void OnEnable()
    {
        objectiveManager.OnObjectiveChanged += UpdateUI;
    }

    void OnDisable()
    {
        objectiveManager.OnObjectiveChanged -= UpdateUI;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateUI(string title, string description)
    {
        titleText.text = title;
        descriptionText.text = description;
    }
}
