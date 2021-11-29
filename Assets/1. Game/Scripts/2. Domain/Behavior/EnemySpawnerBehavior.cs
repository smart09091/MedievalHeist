using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    [SerializeField] float enemySpawnInterval;
    [SerializeField] float nextSpawnTime;
    [SerializeField] int maxEnemyCount;
    [SerializeField] int currentEnemyCount;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;

        GameEvents.Instance.onEnemyDestroyed += DecreaseCurrentEnemyCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            nextSpawnTime += Time.deltaTime;
            if(nextSpawnTime >= enemySpawnInterval){
                while(currentEnemyCount < maxEnemyCount){
                    var spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    if(SpawnPointIsActive(spawnPointIndex)){
                        SpawnEnemy(spawnPointIndex);
                        break;
                    }
                }

                nextSpawnTime = 0;
            }
        }
    }

    private void LateUpdate()
    {


        if (gameStateData.StateChange)
        {

            if (gameStateData.RestartState)
            {
                nextSpawnTime = 0;
                currentEnemyCount = 0;
            }
        }
    }

    bool SpawnPointIsActive(int spawnPointIndex){
        EnemySpawnPointBehavior enemySpawnPointBehavior = spawnPoints[spawnPointIndex].GetComponent<EnemySpawnPointBehavior>();
        return enemySpawnPointBehavior.isActive;
    }

    void SpawnEnemy(int spawnPointIndex){
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
        IncreaseCurrentEnemyCount();
    }

    void IncreaseCurrentEnemyCount(){
        currentEnemyCount++;
    }

    void DecreaseCurrentEnemyCount(){
        currentEnemyCount--;
    }
}
