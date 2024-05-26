using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OathTracker : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Transform spawnPoint;

    public GameObject paladin;

    public GameObject oathbreakFilter;

    public List<GameObject> spawnedPaladinList;

    public int currentOathbreakerValue;
    public int currentOathboundValue;

    public bool isPaladinSpawned = false;
    public bool isOathBroken = false;



    public static Action onOathBreak;

    void Awake()
    {
        RangedAttack.onEnemyKilled += OnEnemyKilled;
        WeaponHitBox.onEnemyKilledMelee += OnEnemyKilledMelee;
    }
    private void Start()
    {
        UIManager.Instance.SetOathValue(UIManager.Instance.oathBreakerText, "Oathbreaker: ", currentOathbreakerValue);
        UIManager.Instance.SetOathValue(UIManager.Instance.oathBoundText, "Oathbound: ", currentOathboundValue);
    }

    private void OnEnemyKilledMelee()
    {
        currentOathbreakerValue = 1;
        UIManager.Instance.SetOathValue(UIManager.Instance.oathBreakerText, "Oathbreaker: ", currentOathbreakerValue);

        if(currentOathbreakerValue >= 5 && !isOathBroken)
        {
            onOathBreak.Invoke();

            isOathBroken = true;

            oathbreakFilter.SetActive(true);

        }
    }

    public void OnEnemyKilled()
    {
        currentOathboundValue += 1;
        UIManager.Instance.SetOathValue(UIManager.Instance.oathBoundText, "Oathbreaker: ", currentOathboundValue);

        if (currentOathboundValue >= 5 && !isPaladinSpawned)
        {
            SpawnPaladin();

            isPaladinSpawned = true;

            onOathBreak.Invoke();
        }
    }

    public void SpawnPaladin()
    {
        paladin.transform.position = spawnPoint.position;
        
        Instantiate(paladin, paladin.transform.position, Quaternion.identity);

        spawnedPaladinList.Add(paladin);

    }

}
