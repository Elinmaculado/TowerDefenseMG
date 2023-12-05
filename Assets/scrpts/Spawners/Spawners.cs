using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawners : MonoBehaviour
{   
    [SerializeField]  List<Enemie> levelEnemies;
    [SerializeField] List<Transform> spawnPositions;
    
    public int totalOfEnemies = 0;

    private Queue<int> enemyTypeQueue = new();
    private Queue<int> spawnPositionQueue = new();
    private Queue<float> delayTime = new();

    #region Spawn Times
    public float firstSpawnDelay = 5.0f;
    float minDelayTime = 5.0f;
    float maxDelayTime = 7.0f;
    #endregion

    [System.Serializable]
    public class Enemie { 
        public GameObject enemieType;
        public int enemyAmount;
    }

 

    private void Start()
    {
        
        GenerateEnemyQueue();
        StartCoroutine(SpawnEnemyDelay());
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

        //Generate delay time queue
        GenerateRandomDelays(); 

        //Generates enemy type queue
        for (int i = 0; i < totalOfEnemies; i++)
        {
            int enemyIndex = UnityEngine.Random.Range(0, tmpEnemies.Count);
            enemyTypeQueue.Enqueue(enemyIndex);
            tmpEnemies[enemyIndex].enemyAmount--;
            if (tmpEnemies[enemyIndex].enemyAmount <= 0)//Deletes enemy from pool once al of them where queued
            {
                tmpEnemies.RemoveAt(enemyIndex);
            }
        }

        //Generate spawn position queue
        for (int j = 0; j < totalOfEnemies; j++)
        {
            spawnPositionQueue.Enqueue(UnityEngine.Random.Range(0, spawnPositions.Count));
        }

        
    }
    
    void SpawnEnemy()
    {

        if(totalOfEnemies > 0)
        {
            GameObject enemyToSpwan = (GameObject)Instantiate
                        (levelEnemies[enemyTypeQueue.Peek()].enemieType, 
                        spawnPositions[spawnPositionQueue.Peek()].transform.position, 
                        levelEnemies[enemyTypeQueue.Peek()].enemieType.transform.rotation);
            enemyToSpwan.GetComponent<EnemyBehavior>().waypoints = spawnPositions[spawnPositionQueue.Peek()].GetComponent<EnemyBehavior>().waypoints;
            spawnPositionQueue.Dequeue();
            enemyTypeQueue.Dequeue(); 
            StartCoroutine(SpawnEnemyDelay());
            totalOfEnemies--;
        }
        else{
            Debug.Log("Level cleared");
        }

    }

    void GenerateRandomDelays()
    {
        delayTime.Enqueue(firstSpawnDelay);
        for(int i = 0; i<totalOfEnemies;i++)
        {
            delayTime.Enqueue(UnityEngine.Random.Range(minDelayTime,maxDelayTime));
            minDelayTime -= minDelayTime > 1.0f ? 0.4f : 0;
            maxDelayTime -= maxDelayTime > 1.5f ? 0.2f : 0;
        }
    }

    IEnumerator SpawnEnemyDelay()
    {
        yield return new WaitForSeconds(delayTime.Peek());
        delayTime.Dequeue();
        SpawnEnemy();
      
    }

  
}
