using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public GameObject AttributeTab;

    public Button[] attributeButtons;

    private void Awake()
    {
        PlayerController.onToggleAttributeTab += ToggleAttributeTab;
        AttributeSystem.noAttributePoints += NoAttributePoints;
        LevelSystem.onLevelUp += OnLevelUp;
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
