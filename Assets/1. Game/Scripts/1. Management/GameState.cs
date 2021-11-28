using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
     /*
     This Manages the state of the game 
     */

    private GameStateData gameStateData;

    private bool isUpdateOnce;


    private void Start()
    {
        gameStateData = Data.gameStateData;
     
    }

    //This is on Fixed update to ensure that the command is called  first before going to the Update and Late Updates
    private void FixedUpdate()
    {    
        


        //Conditions for Main Menu

        //Conditions for Game Play

        //Conditions for LevelClear State

        //Conidtions for Game Over State



    }

    public void playState()
    {
        renewState();
        gameStateData.GameplayState = true;
        StartCoroutine(changeStatusUpdate());
    }

    //will be called next level state for once frame and then restarts the game in the direction you want
    public void nextLevelState() {
        renewState();
        gameStateData.NextLevelState = true;
        RestartState(0);
        StartCoroutine(changeStatusUpdate()) ;
    }


    // This function has 2 types 0 for Play Game 1 for Main menu. Both courotines have flixible time;
    public void RestartState(int type)
    {
        renewState();
        gameStateData.RestartState = true;

        if (type == 0)
        {
            StartCoroutine(startPlayState(0.2f));
        }
        else
        {
            StartCoroutine(toMainState(0.1f));
        }



        StartCoroutine(changeStatusUpdate());

       
    }


    public void levelClearState() {
        renewState();
        gameStateData.LevelClearState = true;
        StartCoroutine(changeStatusUpdate());
         
    }

    private void MainMenuState()
    {
        renewState();
        gameStateData.MainState = true;

        StartCoroutine(changeStatusUpdate());
    }



    public void gameOverState()
    {
        renewState();
        gameStateData.GameOverState = true;
        StartCoroutine(changeStatusUpdate());
    }

    //Resets the States
    private void renewState()
    {
        gameStateData.GameplayState = false;
        gameStateData.GameOverState = false;
        gameStateData.ReviveState = false;
        gameStateData.MainState = false;
        gameStateData.RestartState = false;
        gameStateData.NextLevelState = false;
        gameStateData.LevelClearState = false;
       
    }


    //This ensure that the state change only happens once per frame
    private IEnumerator changeStatusUpdate()
    {
        gameStateData.StateChange = true;     
        yield return new WaitForEndOfFrame();
        gameStateData.StateChange = false;       
        StopCoroutine(changeStatusUpdate());
    }



 


    private IEnumerator toMainState(float time)
    {
        yield return new WaitForSeconds(time);
        MainMenuState();
        StopCoroutine(toMainState(time));
    }


    IEnumerator startPlayState(float time)
    {
        yield return new WaitForSeconds(time);     
        playState();     
        StopCoroutine(startPlayState(time));

    }


}
