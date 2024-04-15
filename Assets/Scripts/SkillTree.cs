using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    public string name;
    public string description;
    public int skillPointCost;
    public int currentLevel;
    public int maxLevel;
}

public class SkillTree : MonoBehaviour
{
    public PlayerExperience playerExperience;
    public Skill[] skills;
    public Text[] skillLevelTexts; // Array of UI Text elements displaying skill levels

    // Call this method to spend skill points on a skill
    public void UpgradeSkill(int index)
    {
        Skill skill = skills[index];
        if (skill.currentLevel < skill.maxLevel && playerExperience.skillPoints >= skill.skillPointCost)
        {
            playerExperience.SpendSkillPoint();
            skill.currentLevel++;
            skillLevelTexts[index].text = "Level: " + skill.currentLevel.ToString();
            ApplySkillEffect(skill);
        }
        else
        {
            Debug.Log("Cannot upgrade skill!");
        }
    }

    void ApplySkillEffect(Skill skill)
    {
        // Apply the effect of the skill
        // You can implement this based on your game mechanics
    }
}
