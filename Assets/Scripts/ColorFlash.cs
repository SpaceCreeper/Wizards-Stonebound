using System;
using System.Collections;
using UnityEngine;

public class ColorFlash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField, Range(0.0f, 1.0f)] private float flashDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void FlashDamage()
    {
        StartCoroutine(FlashCoroutine(Color.red));
    }

    public void FlashHeal()
    {
        StartCoroutine(FlashCoroutine(Color.green));
    }

    IEnumerator FlashCoroutine(Color color)
    {
        spriteRenderer.color = color;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.color = Color.white;
    }
}
