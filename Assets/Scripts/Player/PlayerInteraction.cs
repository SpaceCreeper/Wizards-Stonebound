using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable currentInteractable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out var foundInteractable))
        {
            Debug.Log("Press [E] to interact");
            currentInteractable = foundInteractable;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out var foundInteractable))
        {
            if (foundInteractable == currentInteractable)
            {
                currentInteractable = null;
            }
        }
    }
}
