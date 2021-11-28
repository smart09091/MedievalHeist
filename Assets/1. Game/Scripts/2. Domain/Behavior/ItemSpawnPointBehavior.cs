using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPointBehavior : MonoBehaviour
{
    public bool isInUse;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            isInUse = false;
        }
    }
}
