using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPointBehavior : MonoBehaviour
{
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Player"){
            isActive = false;
        }
    }

    void OnTriggerExit(Collider other){
        
        if(other.tag == "Player"){
            isActive = true;
        }
    }
}
