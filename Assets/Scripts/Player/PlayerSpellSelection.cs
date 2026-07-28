using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpellSelection : MonoBehaviour
{
    [SerializeField] private Spell[] equippedSpells = new Spell[3];
    [SerializeField] private float[] spellNextReadyTime = new float[3];
    public int activeSlotIndex = 0;
    public Spell activeSpell => equippedSpells[activeSlotIndex];

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < 3; i++)
        // {
        //     Debug.Log($"Slot {i} holding {equippedSpells[i]}: {Mathf.Clamp(spellNextReadyTime[i] - Time.time, 0f, Mathf.Infinity)}");
        // }
    }

    public void OnSelectSpell(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            int slotNumber = Mathf.RoundToInt((int)context.ReadValue<float>());
            int selectedSlotIndex = slotNumber - 1;

            if (selectedSlotIndex >= 0 && selectedSlotIndex < equippedSpells.Length)
            {
                activeSlotIndex = selectedSlotIndex;
                Debug.Log($"activeSlotIndex {activeSlotIndex} has been selected.");
                Debug.Log($"Active Spell: {activeSpell.name}");
            }

            // SelectSlot(selectedIndex);
        }
    }

    public bool CanCastActiveSpell()
    {
        return Time.time >= spellNextReadyTime[activeSlotIndex];
    }

    public void TriggerActiveSpellCooldown()
    {
        if (activeSpell != null)
        {
            spellNextReadyTime[activeSlotIndex] = Time.time + activeSpell.cooldownSeconds;
        }
    }

    public float GetRemainingCooldownTime(int index)
    {
        return Mathf.Max(0f, spellNextReadyTime[index] - Time.time);
    }

    public float GetCooldownTime(int index)
    {
        if (equippedSpells[index] != null)
        {
            return equippedSpells[index].cooldownSeconds;
        }
        else
        {
            return 0f;
        }
    }
}
