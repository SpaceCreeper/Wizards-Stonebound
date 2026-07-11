using System;
using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color color = Color.red;
    [SerializeField, Range(0.0f, 1.0f)] private float flashDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = color;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.color = Color.white;
    }
}
