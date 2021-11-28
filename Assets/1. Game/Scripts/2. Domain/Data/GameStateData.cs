using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateData
{
   

    public bool MainState { get; set; }
    public bool GameplayState { get; set; }

    public bool ReviveState { get; set; }
    public bool GameOverState { get; set; }

    public bool RestartState { get; set; }
    public bool StateChange { get; set; }
    public bool NextLevelState { get; set; }

    public bool LevelClearState { get; set; }

}
