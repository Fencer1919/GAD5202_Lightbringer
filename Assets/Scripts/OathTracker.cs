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

    void Awake()
    {
        RangedAttack.onEnemyKilled += OnEnemyKilled;
    }

    public void OnEnemyKilled()
    {
        currentOathValue += 1;
    }

    void Update()
    {
        text.text = currentOathValue.ToString();
        Debug.Log(currentOathValue);
        /*
        if(spawnedPaladinList.Count > maxPaladinCount)
        {
            timer += Time.deltaTime;

            if(timer >= damageInterval)
            {
                DealDamage(damageAmount);
                timer = 0f;
            }
        }
        */
    }

    void DealDamage(int damageAmount)
    {
        playerHealth.CurrentPlayerHealth -= damageAmount;
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
