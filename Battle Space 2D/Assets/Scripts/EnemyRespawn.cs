using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour

{
    public GameObject enemyPrefab;
    public Transform enemyParent;

    float spawnDistance = 25f;

    float enemyRate = 7;
    float nextEnemy = 1;

    // Update is called once per frame
    void Update()
    {
      nextEnemy -= Time.deltaTime;
        
        if(nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(enemyPrefab, transform.position + offset, transform.rotation, enemyParent);
        }
    }
}
