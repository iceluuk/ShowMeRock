using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveProjectile : MonoBehaviour
{
    public float timePerUnit = 0.5f; // Needs to be beat synced
    public static float oneUnit = 1;
    public bool isEnemyWave = false;

    public Transform targetTransform;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float startTime;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (targetTransform != null)
        {
            initialPosition = transform.position;
            targetPosition = targetTransform.position;
            startTime = Time.time;

            // Rotate the projectile to face the target
            transform.LookAt(targetPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            float journeyLength = Vector3.Distance(initialPosition, targetPosition);
            float distanceCovered = (Time.time - startTime) * speed;
            float journeyFraction = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(initialPosition, targetPosition, journeyFraction);

            if (journeyFraction >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;

        if (targetTransform != null)
        {
            // Update the rotation to face the new target
            transform.LookAt(targetTransform.position);
        }
    }
}
