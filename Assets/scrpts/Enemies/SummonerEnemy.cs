using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerEnemy : MonoBehaviour
{
    [SerializeField]EnemyBehavior character;
    public float summonDealy;
    [SerializeField]GameObject summonUnit;


    private void Start()
    {
        StartCoroutine(Summon());
    }

    IEnumerator Summon()
    {
        yield return new WaitForSeconds(summonDealy);
        if (!character.isDead)
        {
            GameObject spawnEnemy = (GameObject)Instantiate(summonUnit, transform.position, transform.rotation);
            spawnEnemy.GetComponent<EnemyBehavior>().waypoints = character.waypoints;
            spawnEnemy.GetComponent<EnemyBehavior>().TargetIndex = character.TargetIndex;
            StartCoroutine(Summon());
        }
    }
}
