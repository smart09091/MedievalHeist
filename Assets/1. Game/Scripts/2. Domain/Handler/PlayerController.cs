using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private enum JumpKey { Space, MouseDown}

    private ControllerData controllerData;

    private GameStateData gameStateData;


    [SerializeField] JumpKey jumpKey;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        controllerData = Data.controllerData;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState)
        {
            switch (jumpKey)
            {
                case JumpKey.Space:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        controllerData.isJump = true;
                    }
                    break;

                case JumpKey.MouseDown:
                    if (Input.GetMouseButtonDown(0))
                    {
                        controllerData.isJump = true;
                    }

                    break;
            }
        }


    }
}
