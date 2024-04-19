using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public PlayerExperience playerExperience; // Reference to the PlayerExperience script
    public int baseXP = 10; // Base XP dropped by this enemy
    public int extraXPPerDifficultyLevel = 5; // Extra XP per difficulty level

    public int GetXP()
    {
        return baseXP;
    }

    // Call this method when the enemy is defeated
    public void Defeated()
    {
        // Add logic for enemy death (e.g., play death animation, disable GameObject)
        //playerExperience.GainXP(GetXP());
    }
}
