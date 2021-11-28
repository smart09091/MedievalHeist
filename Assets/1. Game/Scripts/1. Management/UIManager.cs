using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{    
    /*
     Manages the UI of the game
     */

    private GameStateData gameStateData;
    [SerializeField] 
    GameObject MainMenuPanel,SettingsPanel,GamePlayPanel, LevelClearPanel, GameOverPanel;
    void Start()
    {
        gameStateData = Data.gameStateData;
    }

    //This is on Late Update to ensure that all of the gameobject that uses Fixed Update and Update have been change first before going on this Logic
    void LateUpdate()
    {

        //State Change will only be called Once. This ensure that the panel will only get called once per state and only one panel will be open 
        if (gameStateData.StateChange)
        {
            //resets the panels to false
            renew();

            //reactivate panels
            if (gameStateData.MainState)
            {
                MainMenuPanel.SetActive(true);
            }

            if (gameStateData.GameplayState)
            {
                GamePlayPanel.SetActive(true);
            }

            if (gameStateData.LevelClearState)
            {
                LevelClearPanel.SetActive(true);
            }

            if (gameStateData.GameOverState)
            {
                GameOverPanel.SetActive(true);
            }

        

        }
      

       
    }

    private void renew() {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        GamePlayPanel.SetActive(false);
        LevelClearPanel.SetActive(false);
        GameOverPanel.SetActive(false);

    }
}
