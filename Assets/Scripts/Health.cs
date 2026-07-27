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

    public void ModifyHealth(int amount)
    {
        // healthEffect accepts positive and negative input in the Inspector
        // consider changing to use new variable to select positive/negative instead
        health += amount;
        Debug.Log($"{this.gameObject} says owie by {amount}!");
        Debug.Log($"Health is now: {health}");  

        health = Mathf.Clamp(health, 0, maxHealth);


        OnDamage?.Invoke(); // WARNING: THIS WILL DAMAGE EVEN IF IT HEALS. MAY NEED ENUM CHANGES.

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
