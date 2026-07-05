using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Properties")]
    public int health;
    [SerializeField] private int maxHealth = 100;

    [Header("Events")]
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

    public void TakeDamage(int amount)
    {
        // healthEffect accepts positive and negative input in the Inspector
        // consider changing to use new variable to select positive/negative instead
        health += amount;
        Debug.Log($"{this.gameObject} says owie by {amount}!");
        Debug.Log($"Health is now: {health}");  

        OnDamage?.Invoke();

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
