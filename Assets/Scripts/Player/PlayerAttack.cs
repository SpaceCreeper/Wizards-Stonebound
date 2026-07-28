using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public PlayerSpellSelection playerSpellSelection;
    [SerializeField] private Transform wandTip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpellSelection = GetComponent<PlayerSpellSelection>();
    }
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && playerSpellSelection.CanCastActiveSpell())
        {
            Debug.Log("Pew-pew!");
            Spell activeSpell = playerSpellSelection.activeSpell;

            if (activeSpell == null) return;

            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0f;

            Vector2 fireDirection = (mouseWorldPosition - wandTip.position).normalized;

            activeSpell.Cast(wandTip, fireDirection, this.gameObject);
            playerSpellSelection.TriggerActiveSpellCooldown();
        }
    }
}