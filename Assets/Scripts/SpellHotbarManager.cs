using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpellHotbarManager : MonoBehaviour
{
    public PlayerSpellSelection playerSpellSelection;
    [SerializeField] private GameObject[] hotbarSlots = new GameObject[3];

    private Image[] cooldownOverlays;
    private GameObject[] selectionOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpellSelection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpellSelection>();

        cooldownOverlays = new Image[hotbarSlots.Length];
        selectionOutline = new GameObject[hotbarSlots.Length];

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (hotbarSlots[i] == null) continue;

            Transform cooldownOverlayTransform = hotbarSlots[i].transform.Find("CooldownOverlay");
            if (cooldownOverlayTransform != null)
            {
                cooldownOverlays[i] = cooldownOverlayTransform.GetComponent<Image>();
            }
            
            Transform selectionOutlineTransform = hotbarSlots[i].transform.Find("SelectionOutline");
            if (selectionOutlineTransform != null)
            {
                selectionOutline[i] = selectionOutlineTransform.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            bool isSelected = i == playerSpellSelection.activeSlotIndex;
            selectionOutline[i].SetActive(isSelected);


            float remainingCooldownTime = playerSpellSelection.GetRemainingCooldownTime(i);
            float totalCooldownTime = playerSpellSelection.GetCooldownTime(i);

            if (remainingCooldownTime > 0f && totalCooldownTime > 0f)
            {
                cooldownOverlays[i].fillAmount = Mathf.Floor((remainingCooldownTime / totalCooldownTime) * 10) / 10;
            }
            else
            {
                cooldownOverlays[i].fillAmount = 0f;
            }
        }
    }
}
