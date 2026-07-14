using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    public Spell activeSpell;
    public float spellCooldown;
    private bool canAttack;

    [SerializeField]
    private Transform wandTip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
            Debug.Log("Pew-pew!");

            if (activeSpell == null) return;

            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0f;

            Vector2 fireDirection = (mouseWorldPosition - wandTip.position).normalized;

            activeSpell.Cast(wandTip, fireDirection, this.gameObject);

            StartCoroutine(Cooldown(activeSpell.cooldown));
        }
    }

    IEnumerator Cooldown(float cooldown)
    {
        canAttack = false;

        yield return new WaitForSeconds(cooldown);

        canAttack = true;
    }
}
