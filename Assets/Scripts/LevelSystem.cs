using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private int experience;
    [SerializeField] private int experienceToNextLevel;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        if (experience >= experienceToNextLevel)
        {
            // Enough experience to level up
            level++;
            experience -= experienceToNextLevel;

        }
    }

    public int GetLevelNumber()
    {
        return level;
    }
}
