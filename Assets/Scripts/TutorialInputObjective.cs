using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialInputObjective : Objective
{
    [SerializeField] private InputActionReference inputActionReference;
    private bool actionPerformed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (inputActionReference != null && inputActionReference.action != null)
        {
            inputActionReference.action.performed += OnInputPerformed;
        }
    }

    void OnDisable()
    {
        if (inputActionReference != null && inputActionReference.action != null)
        {
            inputActionReference.action.performed -= OnInputPerformed;
        }
    }

    void OnInputPerformed(InputAction.CallbackContext context)
    {
        if (IsCompleted) return;

        actionPerformed = true;
    }

    protected override bool CompletionCheck()
    {
        return actionPerformed;
    }
}
