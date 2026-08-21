using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Properties")]
    [field: SerializeField] public int health {get; private set;}
    [SerializeField] private int maxHealth = 100;

    [Header("Events")]
    public UnityEvent OnHeal;
    [Space]
    public UnityEvent OnDamage;
    [Space]
    public UnityEvent OnDeath;

    void Awake()
    {
        health = maxHealth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyHealth(int amount)
    {
        // Spell.healthEffect accepts positive and negative input in the Inspector
        // consider changing to use new variable to select positive/negative instead
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        Debug.Log($"{this.gameObject} says owie by {amount}!");
        Debug.Log($"Health is now: {health}");
        
        if (amount > 0)
        {
            OnHeal?.Invoke();
        }
        
        if (amount < 0)
        {
            OnDamage?.Invoke();
        }

        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
