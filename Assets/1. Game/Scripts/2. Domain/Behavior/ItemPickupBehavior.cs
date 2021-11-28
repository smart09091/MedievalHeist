using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    private ScoreData scoreData;
    [SerializeField] int currentItemIndex;
    public Item[] items;
    public GameObject[] itemMeshes;
    bool doOnce = true;

    void Start(){
        gameStateData = Data.gameStateData;
        scoreData = Data.scoreData;
        if(doOnce){
            InitiateItemPickup();
            doOnce = false;
        }
    }

    private void LateUpdate()
    {

        if (gameStateData.GameplayState) { 
        
        }


        if (gameStateData.StateChange)
        {

            if (gameStateData.LevelClearState)
            {
                Destroy(gameObject);
            }

            if (gameStateData.GameOverState)
            {
                Destroy(gameObject);
            }

           
           
        }
    }

    void InitiateItemPickup(){
        currentItemIndex = Random.Range(0, items.Length);
        itemMeshes[currentItemIndex].SetActive(true);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            scoreData.score += items[currentItemIndex].score;
            if(scoreData.score > 150){
                scoreData.score = 150;
            }
            Destroy(gameObject);
        }
    }

    void OnDestroy(){
        GameEvents.Instance.GemCollect();
    }
    
}
