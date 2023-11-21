using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [System.Serializable]
    public class Enemie { 
        public GameObject enemieType;
        public int totalOfEnemies;
    }

    [SerializeField] List<Enemie> enemies;
    [SerializeField] Transform[] spawnPosition;
    

    [SerializeField] int remainingEnemies;

    [SerializeField] float delayTime;

    private void Start()
    {
        SpawnEnemy();
        for(int i = 0; i < enemies.Count -1; i++)
        {
            remainingEnemies += enemies[i].totalOfEnemies;
        }
    }
    void SpawnEnemy()
    {
        int randomSpawnPos = Random.Range(0, spawnPosition.Length);
        int randomEnemyType = Random.Range(0, enemies.Count-1);

        Instantiate(enemies[randomEnemyType].enemieType, spawnPosition[randomSpawnPos].position, enemies[randomEnemyType].enemieType.transform.rotation);
        remainingEnemies--;
        enemies[randomEnemyType].totalOfEnemies -= 1;
        
        if(enemies[randomEnemyType].totalOfEnemies == 0)
        {
            enemies.RemoveAt(randomEnemyType);  
        }
       
        if (enemies.Count >= 0)
        {
             StartCoroutine(SpawnDelay());   
        }
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
