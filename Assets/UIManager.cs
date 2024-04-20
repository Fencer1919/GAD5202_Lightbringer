using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{   
    public GameObject AttributeTab;

    private void Awake()
    {
        PlayerController.onToggleAttributeTab += ToggleAttributeTab;
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
