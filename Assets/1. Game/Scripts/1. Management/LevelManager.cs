using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameStateData gameStateData;
    private LevelData levelData;
    private ScoreData scoreData;
    [SerializeField] private float gameTime;
    [SerializeField] private GameState gameStateManagerReference;

    
    void Start()
    {
        gameStateData = Data.gameStateData;
        levelData = Data.levelData;
        scoreData = Data.scoreData;
        levelData.currentTime = gameTime;
        GameEvents.Instance.onGameOver += GameOver;
    }

    
    void Update()
    {
        if (gameStateData.GameplayState) {
            levelData.currentTime -= Time.deltaTime;

            if(levelData.currentTime <= 0 && scoreData.score < 150){
                gameStateManagerReference.gameOverState();
            }else
            if(scoreData.score == 150){
                gameStateManagerReference.levelClearState();
            }
        }
        
    }

    private void LateUpdate()
    {

        if (gameStateData.GameplayState) { 
        
        }


        if (gameStateData.StateChange)
        {
            if (gameStateData.MainState || gameStateData.RestartState || gameStateData.NextLevelState || gameStateData.GameplayState)
            {
                //resets
                levelData.currentTime = gameTime;
            }

            if(gameStateData.RestartState){
                scoreData.score = 0;
                GameEvents.Instance.GameReset();
            }

            if (gameStateData.LevelClearState)
            {

            }

            if (gameStateData.GameOverState)
            {

            }

           
           
        }
    }

    void GameOver(){
        gameStateManagerReference.gameOverState();
    }
}
