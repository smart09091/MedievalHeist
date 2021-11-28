using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    private PlayerData playerData;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        playerData = Data.playerData;
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            MoveTowardTarget();
            LookAtMovementDirection();
        }
        
    }

    private void LateUpdate()
    {


        if (gameStateData.StateChange)
        {
            if (gameStateData.MainState || gameStateData.RestartState || gameStateData.NextLevelState || gameStateData.GameplayState)
            {

            }

            if (gameStateData.LevelClearState)
            {

            }

            if (gameStateData.GameOverState)
            {

            }

           
           
        }
    }

    void MoveTowardTarget(){
        var speed = moveSpeed * Time.deltaTime;
        var targetVector = Data.playerData.targetVector;
        targetVector = Quaternion.Euler(0, playerCamera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector.normalized * speed;
        transform.position = targetPosition;
    }

    void LookAtMovementDirection(){
        if(playerData.targetVector != Vector3.zero){
            transform.eulerAngles = Data.playerData.targetDirection;
        }
    }


}
