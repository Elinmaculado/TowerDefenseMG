using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{

    [System.Serializable]
    public struct SpawnableEnemy
    {
        public GameObject enemy;
        public int probability;
    }

    public List<SpawnableEnemy> availableEnemies;
    public WayPoints wayPoints;

    private void Awake()
    {
        StartCoroutine(InitialDelay());
    }


    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, availableEnemies[availableEnemies.Count-1].probability);
        
        for(int i = 0; i < availableEnemies.Count; i++)
        {
            if (randomIndex < availableEnemies[i].probability)
            {
               GameObject enemmyToSpawn = (GameObject)Instantiate(availableEnemies[i].enemy,transform.position, availableEnemies[i].enemy.transform.rotation);
                enemmyToSpawn.GetComponent<EnemyBehavior>().waypoints = wayPoints.wayPoints;
                break;
            }
        }

        StartCoroutine(SpawnDelay());
    }



    public float initianMaxTime;
    public float initialMinTime;

    public float minMaxTime;
    public float minMinTime;

    IEnumerator SpawnDelay()
    {
        if (initialMinTime > minMinTime)
        {
            initialMinTime-=0.5f;
        }
        if (initianMaxTime > minMaxTime)
        {
            initianMaxTime-=0.5f;
        }
        yield return new WaitForSeconds(Random.Range(initialMinTime,initianMaxTime));
        SpawnEnemy();
    }

    public List<GameObject> initialEnemies;
    public float initialMaxDelay;
    public float initialMinDelay;
    private void InitialQueue()
    {
        GameObject enemmyToSpawn = (GameObject)Instantiate(initialEnemies[0], transform.position, transform.rotation);
        enemmyToSpawn.GetComponent<EnemyBehavior>().waypoints = wayPoints.wayPoints;
        initialEnemies.RemoveAt(0);
        StartCoroutine(InitialDelay());
    }

    IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(Random.Range(initialMinDelay, initialMaxDelay));
        if (initialEnemies.Count <= 0)
        {
            InitialQueue();
        }
        else
        {
            SpawnEnemy();
        }
    }
}
