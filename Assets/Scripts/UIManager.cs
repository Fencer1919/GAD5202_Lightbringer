using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public static UIManager Instance;

    public GameObject AttributeTab;
    public Button[] attributeButtons;

    public GameObject DungeonTab;
    public CameraAnimationScript cameraAnimationScript;//temporary

    public GameObject restartPanel;

    public Slider healthBar;

    public TMP_Text oathBoundText;
    public TMP_Text oathBreakerText;

    public TMP_Text levelText;

    public TMP_Text strText;
    public TMP_Text dexText;
    public TMP_Text hpText;
    public TMP_Text wisText;
    public TMP_Text intText;
    public TMP_Text hsText;



    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        Destroy(gameObject);


        PlayerController.onToggleAttributeTab += ToggleAttributeTab;
        ChooseLevel.onDungeonSelection += OnDungeonSelection;
        AttributeSystem.noAttributePoints += NoAttributePoints;
        LevelSystem.onLevelUp += OnLevelUp;

        DeadState.onDead += OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        //check these nullchecks later
        if (restartPanel != null)
        {
            restartPanel.SetActive(true);
        }

    }

    private void OnDungeonSelection()
    {
        //check these nullchecks later
        if (DungeonTab != null)
        {
            if (cameraAnimationScript.IsDungeonSelectionActive)
            {
                DungeonTab.SetActive(false);
            }
            else
            {
                DungeonTab.SetActive(true);
            }
        }
    }

    private void Start()
    {
        levelText.text = "Level: 0";
    }

    public void SetAttribute(TMP_Text attributeText, int attributeValue)
    {
        attributeText.text = attributeValue.ToString();
    }

    public void SetOathValue(TMP_Text text, String s,int i)
    {
        text.text = s + i.ToString();
    }

    public void SetHealthBar(float healthAmount)
    {
        healthBar.value = healthAmount;
    }

    private void OnLevelUp(int i)
    {
        levelText.text = "Level: " + i.ToString();

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
        //check these nullchecks later
        if (AttributeTab != null)
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
}
