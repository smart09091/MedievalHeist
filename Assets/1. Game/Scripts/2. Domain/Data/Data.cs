using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Infrastructure;

public class Data : MonoBehaviour
{
    public static SettingsData settingsData { get; set; }
    public static GameStateData gameStateData { get; set; }
    public static CoinData coinData { get; set; }
    public static LevelData levelData { get; set; }
    public static ScoreData scoreData { get; set; }

    public static PlayerData playerData { get; set; }
    public static ControllerData controllerData { get; set; }

    private void Awake()
    {
        settingsData = SettingsPersistence.getData();
        coinData = CoinPersistence.getData();
        levelData = LevelPersistence.getData();
        scoreData = ScorePersistence.getData();
        controllerData = new ControllerData();
        gameStateData = new GameStateData();
        playerData = new PlayerData();
     


    }

    public static void saveData(CoinData data)
    {
        CoinPersistence.saveData(data);
    }
    public static void saveData(LevelData data)
    {
        LevelPersistence.saveData(data);
    }
    public static void saveData(ScoreData data)
    {
        ScorePersistence.saveData(data);
    }
    public static void saveData(SettingsData data)
    {
        SettingsPersistence.saveData(data);
    }



    private void OnApplicationQuit()
    {

        SettingsPersistence.saveData(settingsData);
    }

 
}
