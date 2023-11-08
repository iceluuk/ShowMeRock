using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveProjectile : MonoBehaviour
{
    private FlashEffect flash;
    
    [SerializeField] private float _pulseSize = 1.15f;
    [SerializeField] private float _pulseSpeed = 5f;
    private Vector3 _startSize;
    
    public float timePerUnit = 0.5f; // Needs to be beat synced (always synced with one beat)
    public static float oneUnit = 1; // Set the speed of the projectile based on the distance per beat
    public bool isEnemyWave = false;
    
    public float projectileLifeInSeconds = 6f; //needs beat sync (change to life in beats)
    private float lifeTime;

    private bool canPulse = true;

    private void Start()
    {
        // save original size of object
        flash = GetComponent<FlashEffect>();
        _startSize = transform.localScale;
    }

    void Update(){
        float distanceToMove = Time.deltaTime / timePerUnit * oneUnit;
        transform.Translate(Vector3.forward * distanceToMove);
        
        // Pulse the size back to original
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, Time.deltaTime * _pulseSpeed);
        
        // kill after given time
        if(lifeTime >= projectileLifeInSeconds)
            Kill();
        lifeTime += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player") && isEnemyWave){
            Kill();
        }

        if(other.gameObject.CompareTag("Enemy") && !isEnemyWave){
            Kill();
        }
    }

    public void Kill()
    {
        canPulse = false;
        Destroy(gameObject);
    }
    
    public void Pulse()
    {
        // TODO: Make the bullets flash. Make the flash obkect
        
        if (canPulse)
        {
            transform.localScale = _startSize * _pulseSize;
            // TODO: flashes are instant at this moment. Make them gradual.
            //flash.Flash();
        }
        
    }
}
