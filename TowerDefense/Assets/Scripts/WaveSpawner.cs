using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Transform> enemys;
    public List<Transform> boss;
    public Transform spawnPoint;
    public float timeBetweenWaves = 3f;
    private float countdown = 2f;
    private int waveIndex = 0;
    private int waveQtd = 4;
    public static bool bossCheck = false;
    void Update() 
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnerWave());
            SpawnerWave();
            countdown = timeBetweenWaves;
        }
        
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnerWave()
    {
        if(!bossCheck)
        {
            if(PlayerStats.Rounds % 4 == 0)
                waveQtd++;
            PlayerStats.Rounds++;
            for (int i = 0; i < waveQtd; i++)
            {
                SpawnerEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void SpawnerEnemy()
    {
        if(!bossCheck)
        {
            if(PlayerStats.Rounds % 5 == 0)
            {
                Instantiate(boss[Random.Range(0, boss.Count)], spawnPoint.position + boss[0].position, spawnPoint.rotation);
                bossCheck = true;

            } else 
            {
                Instantiate(enemys[Random.Range(0, enemys.Count)], spawnPoint.position + enemys[0].position, spawnPoint.rotation);
            }
        }
    }
}
