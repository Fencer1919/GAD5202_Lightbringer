using System.Collections;
using System.Collections.Generic;
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

    private static OathTracker _instance;

    // Bu metod, Singleton örneğini döndürür. Eğer örnek yoksa, oluşturur ve döndürür.
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


    void Update()
    {
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
