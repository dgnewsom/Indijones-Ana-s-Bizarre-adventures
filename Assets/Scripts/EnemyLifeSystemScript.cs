using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLifeSystemScript : LifeSystemScript
{
    
    [SerializeField]
    private float respawnDelay = 10f;
    [SerializeField]
    private Enemy enemyType;
    private EnemySpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();        
    }

    public override void DeathBehaviour()
    {
        if (deathGameObject != null)
        {
            Instantiate(deathGameObject, deathGameObject.transform.position, deathGameObject.transform.rotation).SetActive(true);
        }

        if (enemyType.Equals(Enemy.Chicken)){
            ChickenAgent agent = gameObject.GetComponent<ChickenAgent>();
            spawner.SpawnEnemy(enemyType, agent.initialPosition, respawnDelay, agent.waypointsToFollow);
        }
        else if (enemyType.Equals(Enemy.Skeleton))
        {
            SkeletonAgent agent = gameObject.GetComponent<SkeletonAgent>();
            spawner.SpawnEnemy(enemyType, agent.initialPosition, respawnDelay, agent.waypointsToFollow);
        }
        
        if (disableOnDeath)
        {
            gameObject.SetActive(false);
        }
        else if (destroyOnDeath)
        {
            Destroy(gameObject);
        }


    }

   
}
