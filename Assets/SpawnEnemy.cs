using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy _instance;
    public static SpawnEnemy Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SpawnEnemy>();
            }

            return _instance;
        }
    }
    WaveManager waveManager;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        Spawners = GameObject.FindGameObjectsWithTag("SpawnPoints").ToList();
        waveManager = WaveManager._instance;
    }
    public int maxEnemies = 10;
    public int waveMaxEnemies;
    public List<GameObject> Spawners;
    public int count = 0;
    public GameObject PrefabZombie;
    public GameObject PrefabOgre;
    public int totalSpawned;

    public void Spawn()
    {
        UIElements._instance.setWaveText(waveManager.wave +1);
        waveMaxEnemies = waveManager.enemyThreshholds[waveManager.wave];
        maxEnemies = 100;
        if (totalSpawned >= waveMaxEnemies && count == 0)
        {
            waveManager.wave++;
            count = 0;
            totalSpawned = 0;
        }
        if (Spawners == null) return;
        if (Spawners.Count() < 1) return;
        if (count >= maxEnemies) return;
        if (totalSpawned >= waveMaxEnemies) return;
        

        int index = Random.Range(0, Spawners.Count() - 1);
        Vector3 pos = Spawners[index].transform.position;
        GameObject Prefab = EnemySelector();
        GameObject enemy = Instantiate(Prefab, pos, Quaternion.identity);
        count++;
        totalSpawned++;
        enemy.transform.position = pos;
        enemy.SetActive(true);
        enemy.tag = "Enemy";
    }

    GameObject EnemySelector() 
    {
        GameObject[] prefabs = { PrefabZombie, PrefabOgre };
        return prefabs[Random.Range(0, 1)];
    }

    private void Update()
    {
        Spawn();
    }
}
