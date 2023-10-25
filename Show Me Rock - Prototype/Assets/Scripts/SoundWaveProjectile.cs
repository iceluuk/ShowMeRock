using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveProjectile : MonoBehaviour
{
    public float timePerUnit = 0.5f; // Needs to be beat synced
    public static float oneUnit = 1;
    public bool isEnemyWave = false;

    void Start(){

    }

    void Update(){
        float distanceToMove = Time.deltaTime / timePerUnit * oneUnit;
        transform.Translate(Vector3.forward * distanceToMove);
    }

    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player") && isEnemyWave){
            
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Enemy") && !isEnemyWave){

            Destroy(gameObject);
        }
    }
}
