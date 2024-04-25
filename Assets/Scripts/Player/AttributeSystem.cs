using System;
using UnityEngine;

public class AttributeSystem : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerHealth playerHealth;
    public WeaponHitBox weaponHitBox;
    public RangedAttack rangedAttack;
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

    //Base Stats
    [SerializeField] private float baseDamageMelee;
    [SerializeField] private float critChance;
    [SerializeField] private float baseHP;
    [SerializeField] private float baseDamageRanged;
    [SerializeField] private float baseRangedCooldown;
    [SerializeField] private float baseDodgeCooldown;

    public int spendableAttributePoints;

    public static event Action noAttributePoints;

    // Update attributes based on modifiers
    /*
    private void UpdateAttributes()
    {
        weaponHitBox.MeleeDamage += baseDamageMelee * 0.1f;
        critChanceModifier = dexterity * 0.01f;
        playerHealth.MaxHealth += baseHP * 0.05f;
        rangedAttack.rangedDamage += baseDamageRanged * 0.1f;
        rangedCooldownModifier = 1f - (wisdom * 0.01f);
        dodgeCooldownModifier = 1f - (haste * 0.01f);
    }
    */
    public void Awake()
    {
        LevelSystem.onLevelUp += OnLevelUp;
    }

    private void OnLevelUp()
    {
        spendableAttributePoints = 2;
    }

    private void SetAllButtonsDisabled()
    {
        noAttributePoints.Invoke();
    }

    // Setters for attribute points
    public void SetStrength(int value)
    {
        strength += value;

        weaponHitBox.MeleeDamage += baseDamageMelee * 0.1f;

        spendableAttributePoints--;

        if(spendableAttributePoints < 1)
        {
            SetAllButtonsDisabled();
        }

        //UpdateAttributes();
    }

    public void SetDexterity(int value)
    {
        dexterity += value;

        critChanceModifier = dexterity * 0.01f;

        spendableAttributePoints--;

        if(spendableAttributePoints < 1)
        {
            SetAllButtonsDisabled();
        }

        //UpdateAttributes();
    }

    public void SetHealthPoints(int value)
    {
        healthPoints += value;

        playerHealth.MaxHealth += baseHP * 0.05f;

        spendableAttributePoints--;

        if(spendableAttributePoints < 1)
        {
            SetAllButtonsDisabled();
        }

        //UpdateAttributes();
    }

    public void SetIntelligence(int value)
    {
        intelligence += value;

        rangedAttack.rangedDamage += baseDamageRanged * 0.1f;

        spendableAttributePoints--;

        if(spendableAttributePoints < 1)
        {
            SetAllButtonsDisabled();
        }

        //UpdateAttributes();
    }

    public void SetWisdom(int value)
    {
        wisdom += value;

        rangedCooldownModifier = baseRangedCooldown - (wisdom * 0.01f);

        spendableAttributePoints--;

        if(spendableAttributePoints < 1)
        {
            SetAllButtonsDisabled();
        }

        //UpdateAttributes();
    }

    public void SetHaste(int value)
    {
        haste += value;

        dodgeCooldownModifier = baseDodgeCooldown - (haste * 0.01f);

        spendableAttributePoints--;

        if(spendableAttributePoints < 1)
        {
            SetAllButtonsDisabled();
        }

        //UpdateAttributes();
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
