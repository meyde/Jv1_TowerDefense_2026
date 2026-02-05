using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyWave> wavesList;
    
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
    {
        var currentWave = wavesList[Random.Range(0, wavesList.Count)];
        
        foreach(EnemyContainer enemy in currentWave.enemiesInWave)
        {
            Instantiate(enemy,transform);
            yield return new WaitForSeconds(currentWave.waitTime);
        }
    }
}
