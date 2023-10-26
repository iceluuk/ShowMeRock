using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject enemySoundWave;
    public float enemyProjectileLifeInSeconds = 6f; //needs beat sync (change to life in beats)
    public float timePerAttackInSeconds = 1f; //needs beat sync (Change to attack per beats)
    
    private Transform playerTransform;
    private float laneAngle;

    private float attackAngle;

    void Start()
    {
        playerTransform = GameManager.Instance.playerTransform;
        laneAngle = GameManager.Instance.laneAngle;
        attackAngle = laneAngle;

        InvokeRepeating("Attack", 0f, timePerAttackInSeconds);
    }

    void Attack()
    {
        Vector3 lookDirection = playerTransform.position - transform.position;
        Quaternion attackRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        GameObject currentSoundWave = Instantiate(enemySoundWave, transform.position, attackRotation);
        Destroy(currentSoundWave, enemyProjectileLifeInSeconds);
    }
}

