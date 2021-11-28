using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    
    public static GameEvents Instance;

    public event Action onGemSpawn;
    public event Action onGemCollect;
    public event Action onEnemyAttack;
    public event Action onEnemyDestroyed;
    public event Action onGameOver;
    public event Action onGameReset;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    
    public void GemCollect(){
        if(onGemCollect != null){
            onGemCollect();
        }
    }
    
    public void EnemyAttack(){
        if(onEnemyAttack != null){
            onEnemyAttack();
        }
    }
    
    public void EnemyDestroyed(){
        if(onEnemyDestroyed != null){
            onEnemyDestroyed();
        }
    }
    
    public void GameOver(){
        if(onGameOver != null){
            onGameOver();
        }
    }
    
    public void GameReset(){
        if(onGameReset != null){
            onGameReset();
        }
    }
}
