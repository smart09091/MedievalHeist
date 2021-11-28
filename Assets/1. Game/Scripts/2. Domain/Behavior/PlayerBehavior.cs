using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    private PlayerData playerData;
    private Animator animator;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] AudioSource playerHitAudio;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        playerData = Data.playerData;
        animator = GetComponentInChildren<Animator>();
        startPosition = transform.position;
        GameEvents.Instance.onEnemyDestroyed += PlayPlayerHitAudio;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            UpdateAnimator();
        }
    }

    private void LateUpdate()
    {


        if (gameStateData.StateChange)
        {
            if (gameStateData.MainState || gameStateData.RestartState || gameStateData.NextLevelState || gameStateData.GameplayState)
            {
                ResetPlayer();
            }

            if (gameStateData.LevelClearState)
            {
                animator.SetTrigger("IsVictorious");
            }

            if (gameStateData.GameOverState)
            {
                animator.SetTrigger("IsDefeated");
            }

           
           
        }
    }

    void UpdateAnimator(){
        if(playerData.targetVector != Vector3.zero){
            animator.SetBool("IsRunning", true);
        }else{
            animator.SetBool("IsRunning", false);
        }
    }

    void ResetPlayer(){
        animator.SetTrigger("ResetPlayer");
        transform.position = startPosition;
    }

    void PlayPlayerHitAudio(){
        if (gameStateData.GameplayState) {
            playerHitAudio?.Play();
        }
    }
}
