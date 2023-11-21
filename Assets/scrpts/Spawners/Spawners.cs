using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [System.Serializable]
    public struct Enemie { 
        public GameObject enemieType;
        public int totalOfEnemies;
    }

    [SerializeField] Enemie[] enemies;
    [SerializeField] Transform[] spawnPosition;
    

    [SerializeField] int remainingEnemies;

    [SerializeField] float delayTime;

    private void Start()
    {
        SpawnEnemy();
        for(int i = 0; i < enemies.Length; i++)
        {
            remainingEnemies += enemies[i].totalOfEnemies;
        }
    }
    void SpawnEnemy()
    {
        int randomSpawnPos = Random.Range(0, spawnPosition.Length);
        int randomEnemyType = Random.Range(0, enemies.Length);

        do
        {
            if (enemies[randomEnemyType].totalOfEnemies > 0)
            {
                Instantiate(enemies[randomEnemyType].enemieType, spawnPosition[randomSpawnPos].position, enemies[randomEnemyType].enemieType.transform.rotation);
                remainingEnemies--;
                enemies[randomEnemyType].totalOfEnemies--;
                StartCoroutine(SpawnDelay());
            }
            else
            {

                randomEnemyType = randomEnemyType==enemies.Length? 0 : randomEnemyType + 1;
            }  
        } while (enemies[randomEnemyType].totalOfEnemies == 0) ;
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(delayTime);
        if (remainingEnemies > 0)
        {
            SpawnEnemy();
        }
    }
    
}
