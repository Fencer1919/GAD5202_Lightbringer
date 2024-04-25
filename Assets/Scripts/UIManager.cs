using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public static UIManager Instance;

    public GameObject AttributeTab;

    public Button[] attributeButtons;

    public Slider healthBar;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        Destroy(gameObject);

        PlayerController.onToggleAttributeTab += ToggleAttributeTab;
        AttributeSystem.noAttributePoints += NoAttributePoints;
        LevelSystem.onLevelUp += OnLevelUp;
    }

    public void SetHealthBar(float healthAmount)
    {
        healthBar.value = healthAmount;
    }

    private void OnLevelUp()
    {
        foreach (Button button in attributeButtons)
        {
            button.interactable = true;
        }
    }

    private void NoAttributePoints()
    {
        foreach (Button button in attributeButtons)
        {
            button.interactable = false;
        }
    }

    private void ToggleAttributeTab()
    {
        if (PlayerController.Instance.IsAttributeTab)
        {
            AttributeTab.SetActive(true);
        }
        else
        {
            AttributeTab.SetActive(false);
        }

    }
}
