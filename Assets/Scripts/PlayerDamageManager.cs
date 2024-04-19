using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
        public static event Action<float> EnemyDamaged;

        public void DamageEnemy(float damage)
        {
            EnemyDamaged?.Invoke(damage);
        }
}
