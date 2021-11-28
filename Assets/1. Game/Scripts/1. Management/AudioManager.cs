using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameStateData gameStateData;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource itemPickupAudioSource;
    bool doOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        gameStateData = Data.gameStateData;
        GameEvents.Instance.onGemCollect += PlayGemCollectAudio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {


        if (gameStateData.StateChange)
        {
            if(gameStateData.GameplayState){
                if(doOnce){
                    bgmAudioSource?.Play();
                    doOnce = false;
                }
            }
           
        }
    }

    void PlayGemCollectAudio(){
        if (gameStateData.GameplayState) {
            itemPickupAudioSource?.Play();
        }
    }

    void OnDestroy(){
        GameEvents.Instance.onGemCollect -= PlayGemCollectAudio;
    }
}
