using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private int experience;
    [SerializeField] private int[] experienceToNextLevel = {
        100, 200, 300, 400, 600, 800, 1000, 1200, 1400, 1600,
        1800, 2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400,
        3600, 3800, 4000, 4500, 5000, 5500, 6000, 6500, 7000,
        7500, 8000, 8500, 9000, 9500, 10000};

    void Awake()
    {
        EnemyHealth.onEnemyDeath += AddExperience;
    }

    public LevelSystem()
    {
        level = 0;
        experience = 0;
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        while (experience >= experienceToNextLevel[level] && level < experienceToNextLevel.Length - 1)
        {
            // Enough experience to level up
            experience -= experienceToNextLevel[level];
            level++;
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        if (level >= experienceToNextLevel.Length - 1)
        {
            // Player reached max level
            return 1f;
        }
        else
        {
            return (float)experience / experienceToNextLevel[level];
        }
    }
}
