using System.Collections;
using System.Collections.Generic;
using SonicBloom.Koreo;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject enemySoundWave;
    
    private Transform playerTransform;
    private float laneAngle;

    private float attackAngle;
    
    void Start()
    {  
        playerTransform = GameManager.Instance.playerTransform;
        laneAngle = GameManager.Instance.laneAngle;
        attackAngle = laneAngle;
    }

    public void Attack()
    {
        Vector3 lookDirection = playerTransform.position - transform.position;
        Quaternion attackRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        GameObject currentSoundWave = Instantiate(enemySoundWave, transform.position, attackRotation);
    }

    void OnBeatDrops(KoreographyEvent evt)
    {
        Debug.Log("Shooting on beat");
        Attack();
    }
    
}

