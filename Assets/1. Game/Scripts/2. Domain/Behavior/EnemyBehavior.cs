using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private GameStateData gameStateData;
    private ScoreData scoreData;
    Animator animator;
    GameObject target;
    NavMeshAgent agent;
    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        scoreData = Data.scoreData;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        target = PlayerManager.Instance.GetPlayer();

        GameEvents.Instance.onGameReset += DestroyEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateData.GameplayState) {
            if(isActive){
                agent.SetDestination(target.transform.position);
                animator.SetBool("IsRunning", true);
            }
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
                agent.isStopped = true;
                animator.SetBool("IsRunning", false);
                animator.SetTrigger("IsVictorious");
            }

            if(gameStateData.RestartState){
                Destroy(gameObject);
            }

            if (gameStateData.GameOverState)
            {
                agent.isStopped = true;
                animator.SetTrigger("IsDefeated");
            }

           
           
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(gameStateData.GameplayState){
            ContactPoint contact = collision.contacts[0];
            if(contact.otherCollider.tag == "Player"){
                scoreData.score -= 15;
                if(scoreData.score <= 0){
                    scoreData.score = 0;
                    GameEvents.Instance.GameOver();
                }
                Destroy(gameObject);
            }
        }
    }
    
    void DestroyEnemy(){
        Destroy(gameObject);
    }

    void OnDestroy(){
        GameEvents.Instance.onGameReset -= DestroyEnemy;
        GameEvents.Instance.EnemyDestroyed();
    }

}
