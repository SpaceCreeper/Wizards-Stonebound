using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [Header("References")]
    public Slider slider;
    public Health playerHealth;

    [Header("Fill")]
    public Image fill;

    public Color healthy;
    public Color danger;
    public Color critical;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerHealth != null) return;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.health;

        if (playerHealth.health >= 50)
        {
            fill.color = healthy;
        }
        else if (playerHealth.health > 25 && playerHealth.health < 50)
        {
            fill.color = danger;
        }
        else if (playerHealth.health <= 25)
        {
            fill.color = critical;
        }
    }
}
