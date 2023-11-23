using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawners : MonoBehaviour
{   
    [SerializeField]  List<Enemie> levelEnemies;
    [SerializeField] Transform[] spawnPositions;
    
    public int totalOfEnemies = 0;

    public List<int> enemyTypeQueue = new();
    public List<int> spawnPositionQueue = new();

    int spawnIndex = 0;


    public float spawnDelay = 1.0f;
    [System.Serializable]
    public class Enemie { 
        public GameObject enemieType;
        public int enemyAmount;
    }

 

    private void Start()
    {
        
        GenerateEnemyQueue();
        SpawnEnemy();   
    }

    private void GenerateEnemyQueue()
    {
        //Copies enemies so we can eliminate them from the pool once all of them where queued
        List<Enemie> tmpEnemies = levelEnemies.ToList();

        //Calculates the total amount of enemies
        for (int i = 0; i < levelEnemies.Count; i++)
        {
            totalOfEnemies += tmpEnemies[i].enemyAmount;
        }

        //Generates enemy type queue
        for (int i = 0; i < totalOfEnemies; i++)
        {
            int enemyIndex = UnityEngine.Random.Range(0, tmpEnemies.Count);
            enemyTypeQueue.Add(enemyIndex);
            tmpEnemies[enemyIndex].enemyAmount--;
            if (tmpEnemies[enemyIndex].enemyAmount <= 0)//Deletes enemy from pool once al of them where queued
            {
                tmpEnemies.RemoveAt(enemyIndex);
            }
        }

        //Generate spawn position queue
        for (int j = 0; j < totalOfEnemies; j++)
        {
            spawnPositionQueue.Add(UnityEngine.Random.Range(0, spawnPositions.Length));
        }

        
    }
    
    void SpawnEnemy()
    {

        if(totalOfEnemies > 0)
        {
            Instantiate(levelEnemies[enemyTypeQueue[spawnIndex]].enemieType, 
                        spawnPositions[spawnPositionQueue[spawnIndex]].transform.position, 
                        levelEnemies[enemyTypeQueue[spawnIndex]].enemieType.transform.rotation);
            spawnIndex++;   
            StartCoroutine(SpawnEnemyDelay());
            totalOfEnemies--;
        }
        else{
            Debug.Log("Level cleared");
        }

    }

    IEnumerator SpawnEnemyDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
      
    }
}
