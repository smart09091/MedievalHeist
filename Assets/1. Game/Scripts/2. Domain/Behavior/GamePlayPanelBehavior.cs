using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayPanelBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    private LevelData levelData;
    private ScoreData scoreData;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Animator hitEffectAnimator;
    // Start is called before the first frame update
    void Start()
    {

        gameStateData = Data.gameStateData;
        levelData = Data.levelData;
        scoreData = Data.scoreData;

        GameEvents.Instance.onGemCollect += UpdateScore;
        GameEvents.Instance.onEnemyDestroyed += UpdateScore;
        GameEvents.Instance.onEnemyDestroyed += PlayTakingHitAnimation;
        GameEvents.Instance.onGameReset += UpdateScore;

        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            DisplayTime();
        }
    }

    void DisplayTime(){
        var currentTime = levelData.currentTime;

        if(currentTime < 0){
            currentTime = 0;
        }else
        if(currentTime > 0){
            currentTime += 1;
        }

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateScore(){
        scoreText.text = "" + scoreData.score;
    }

    void PlayTakingHitAnimation(){
        if(gameStateData.GameplayState){
            hitEffectAnimator.SetTrigger("IsTakingHit");
        }
    }
}
