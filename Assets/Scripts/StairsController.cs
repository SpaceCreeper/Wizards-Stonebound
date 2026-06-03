using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class StairsController : MonoBehaviour, IInteractable
{
    public GameObject oppositeStair;

    private bool playerIsInTrigger;
    private PlayerMovement playerMovement;
    private bool canTeleport;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTeleport = true; // consider using playerIsInTrigger
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTeleport = false;
        }
    }

    public void Interact()
    {
        if (canTeleport && oppositeStair)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = oppositeStair.transform.position;
        }
    }
}
