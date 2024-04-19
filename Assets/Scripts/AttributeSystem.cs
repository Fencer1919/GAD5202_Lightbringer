using UnityEngine;

public class AttributeSystem : MonoBehaviour
{
    // Define attributes
    [SerializeField] private int strength = 0;
    [SerializeField] private int dexterity = 0;
    [SerializeField] private int healthPoints = 0;
    [SerializeField] private int intelligence = 0;
    [SerializeField] private int wisdom = 0;
    [SerializeField] private int haste = 0;

    // Define modifiers for attributes
    private float meleeDamageModifier = 1f;
    private float critChanceModifier = 0f;
    private float healthPointsModifier = 1f;
    private float rangedDamageModifier = 1f;
    private float rangedCooldownModifier = 1f;
    private float dodgeCooldownModifier = 1f;

    // Update attributes based on modifiers
    private void UpdateAttributes()
    {
        meleeDamageModifier = 1f + (strength * 0.02f);
        critChanceModifier = dexterity * 0.01f;
        healthPointsModifier = 1f + (healthPoints * 0.01f);
        rangedDamageModifier = 1f + (intelligence * 0.02f);
        rangedCooldownModifier = 1f - (wisdom * 0.01f);
        dodgeCooldownModifier = 1f - (haste * 0.01f);
    }

    // Setters for attribute points
    public void SetStrength(int value)
    {
        strength = value;
        UpdateAttributes();
    }

    public void SetDexterity(int value)
    {
        dexterity = value;
        UpdateAttributes();
    }

    public void SetHealthPoints(int value)
    {
        healthPoints = value;
        UpdateAttributes();
    }

    public void SetIntelligence(int value)
    {
        intelligence = value;
        UpdateAttributes();
    }

    public void SetWisdom(int value)
    {
        wisdom = value;
        UpdateAttributes();
    }

    public void SetHaste(int value)
    {
        haste = value;
        UpdateAttributes();
    }

    // Getters for attribute modifiers
    public float GetMeleeDamageModifier()
    {
        return meleeDamageModifier;
    }

    public float GetCritChanceModifier()
    {
        return critChanceModifier;
    }

    public float GetHealthPointsModifier()
    {
        return healthPointsModifier;
    }

    public float GetRangedDamageModifier()
    {
        return rangedDamageModifier;
    }

    public float GetRangedCooldownModifier()
    {
        return rangedCooldownModifier;
    }

    public float GetDodgeCooldownModifier()
    {
        return dodgeCooldownModifier;
    }
}
