using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawnerBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    [SerializeField] float gemSpawnInterval;
    [SerializeField] float nextSpawnTime;
    [SerializeField] int maxGemCount;
    [SerializeField] int currentGemCount;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject gemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        GameEvents.Instance.onGemCollect += DecreaseCurrentGemCount;
        SpawnGems();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            nextSpawnTime += Time.deltaTime;
            if(nextSpawnTime >= gemSpawnInterval){
                while(currentGemCount < maxGemCount){
                    var spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    if(!SpawnPointIsInUse(spawnPointIndex)){
                        SpawnGem(spawnPointIndex);
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
                currentGemCount = 0;
                DeactivateSpawnPoints();
                SpawnGems();
            }
        }
    }

    void SpawnGems(){
        for(int i = 0; i < maxGemCount; i++){
            if(!SpawnPointIsInUse(i)){
                SpawnGem(i);
            }
        }
    }

    bool SpawnPointIsInUse(int spawnPointIndex){
        ItemSpawnPointBehavior itemSpawnPointBehavior = spawnPoints[spawnPointIndex].GetComponent<ItemSpawnPointBehavior>();
        return itemSpawnPointBehavior.isInUse;
    }

    void SpawnGem(int spawnPointIndex){
        GameObject spawnedGem = Instantiate(gemPrefab, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
        spawnPoints[spawnPointIndex].GetComponent<ItemSpawnPointBehavior>().isInUse = true;
        IncreaseCurrentGemCount();
    }
    void DeactivateSpawnPoints(){
        for(int i = 0; i < spawnPoints.Length; i++){
            spawnPoints[i].GetComponent<ItemSpawnPointBehavior>().isInUse = false;
        }
    }

    void IncreaseCurrentGemCount(){
        currentGemCount++;
    }

    void DecreaseCurrentGemCount(){
        currentGemCount--;
    }
}
