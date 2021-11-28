using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private GameStateData gameStateData;
    private PlayerData playerData;
    public Vector2 InputVector;
    [SerializeField] Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        playerData = Data.playerData;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            InputVector = new Vector2(h, v);

            if(InputVector == Vector2.zero){
                h = joystick.Horizontal;
                v = joystick.Vertical;
                InputVector = new Vector2(joystick.Horizontal, joystick.Vertical);
            }

            Data.playerData.targetVector = new Vector3(h, 0, v);
            Data.playerData.targetDirection = Vector3.up * Mathf.Atan2(h, v) * Mathf.Rad2Deg;
        }
        
    }
}
