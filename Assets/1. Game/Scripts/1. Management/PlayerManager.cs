using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private GameObject player;
    // Start is called before the first frame update
    void 
    Awake()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public GameObject GetPlayer(){
        return player;
    }


    
}
