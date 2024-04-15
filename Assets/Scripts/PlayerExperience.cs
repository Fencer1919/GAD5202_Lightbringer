using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentXP = 0;
    public int level = 1;
    public int xpToNextLevel = 100;
    public int skillPoints = 0;
    public Text xpText;
    public Text levelText;
    public Text skillPointsText;

    // Call this method whenever the player earns XP
    public void GainXP(int amount)
    {
        currentXP += amount;
        xpText.text = "XP: " + currentXP.ToString();

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        levelText.text = "Level: " + level.ToString();
        skillPoints++; // Gain 1 skill point on level up
        skillPointsText.text = "Skill Points: " + skillPoints.ToString();

        // Increase XP required for next level (you can modify this formula)
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f);
        currentXP = 0;
    }

    // Call this method to spend skill points on a skill
    public void SpendSkillPoint()
    {
        if (skillPoints > 0)
        {
            // Logic to unlock or upgrade a skill
            // Decrement skillPoints after spending
            skillPoints--;
            skillPointsText.text = "Skill Points: " + skillPoints.ToString();
        }
        else
        {
            Debug.Log("Not enough skill points!");
        }
    }
}
