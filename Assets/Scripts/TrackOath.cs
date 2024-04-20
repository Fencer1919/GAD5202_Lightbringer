using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackOath : MonoBehaviour
{
    private static OathTracker _instance;

    public static OathTracker Instance
    {
        get
        {
            // Eğer örnek yoksa, oluştur
            if (_instance == null)
            {
                // Bir GameObject oluştur ve bu sınıfa bağla
                GameObject singletonObject = new GameObject("SingletonExample");
                _instance = singletonObject.AddComponent<OathTracker>();
                DontDestroyOnLoad(singletonObject); // Yeni sahnelerde bu nesnenin yok olmasını engeller
            }
            return _instance;
        }
    }

    public int OathValue { get => oathValue; set => oathValue = value; }

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

    private int currentOathValue;

    private int oathValue;

    public TMP_Text text;




    void Update()
    {
        text.text = OathValue.ToString();
        Debug.Log(OathValue);
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
