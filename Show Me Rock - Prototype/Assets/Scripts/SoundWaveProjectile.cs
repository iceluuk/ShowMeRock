using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveProjectile : MonoBehaviour
{
    public float timePerUnit = 0.5f; // Needs to be beat synced (always synced with one beat)
    public static float oneUnit = 1; // Set the speed of the projectile based on the distance per beat
    public bool isEnemyWave = false;

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
