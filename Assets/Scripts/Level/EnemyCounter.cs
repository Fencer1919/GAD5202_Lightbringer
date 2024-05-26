using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    public List<GameObject> areas;

    public GameObject bossDoor;

    private void Awake()
    {
        EnemyHealth.onEnemyDeath += onEnemyDeath;
    }

    void Start()
    {
        for (int i = 0; i < areas.Count; i++)
        {
            for(int j = 0; j < areas[i].transform.childCount; j++) 
            {
                enemies.Add(areas[i].transform.GetChild(j).gameObject);
            }
            
        }
    }
    private void onEnemyDeath(int i, GameObject gameObject)
    {
        enemies.Remove(gameObject);

        if (enemies.Count == 0)
        {
            OpenBossArea();
        }
    }
    private void OpenBossArea()
    {
        bossDoor.SetActive(false);
    }

}
