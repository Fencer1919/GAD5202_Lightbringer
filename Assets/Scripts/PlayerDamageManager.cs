using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    public static event Action<float> EnemyDamaged;

    public static PlayerDamageManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    public void DamageEnemy(float damage)
    {
        EnemyDamaged?.Invoke(damage);
    }
}
