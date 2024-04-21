using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OathTracker : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int count = 0;
    public int targetCount = 5;

    public int maxPaladinCount;

    public Transform spawnPoint;

    public GameObject paladin;

    public List<GameObject> spawnedPaladinList;

    public int damageInterval;
    public int damageAmount;
    private float timer;

    public int currentOathValue;

    public TMP_Text text;

    public bool isPaladinSpawned = false;
    public bool isOathBroken = false;

    public static Action onOathBreak;

    void Awake()
    {
        RangedAttack.onEnemyKilled += OnEnemyKilled;
        WeaponHitBox.onEnemyKilledMelee += OnEnemyKilledMelee;
    }

    private void OnEnemyKilledMelee()
    {
        currentOathValue -= 1;

        if(currentOathValue <= -5 && !isOathBroken)
        {
            onOathBreak.Invoke();

            isOathBroken = true;
        }
    }

    public void OnEnemyKilled()
    {
        currentOathValue += 1;

        if(currentOathValue >= 5 && !isPaladinSpawned)
        {
            SpawnPaladin();

            isPaladinSpawned = true;

            onOathBreak.Invoke();
        }
    }

    void Update()
    {
        text.text = currentOathValue.ToString();
    }

    public void SpawnCounter()
    {
        count ++;

        if(count >= targetCount)
        {
            SpawnPaladin();
            count = 0;
        }
    }

    public void SpawnPaladin()
    {
        paladin.transform.position = spawnPoint.position;
        
        Instantiate(paladin, paladin.transform.position, Quaternion.identity);

        spawnedPaladinList.Add(paladin);

    }

}
