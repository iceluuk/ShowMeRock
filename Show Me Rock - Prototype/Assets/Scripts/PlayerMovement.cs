using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public bool isDashing = false;

    [Tooltip("Variables assigned via Game Manager")]
    //Variables set by gamemanager
    private Transform enemy;
    private float circleRadius;
    private float dashAmountInAngles;
    private float dashDuration = 0.2f; // Needs beat sync!

    private float currentDashAngle = 0f;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float dashStartTime;

    private void Start()
    {
        //Set variables form Game Manager
        enemy = GameManager.Instance.enemyTransform;
        circleRadius = GameManager.Instance.arenaRadius;
        dashAmountInAngles = GameManager.Instance.laneAngle;

        //Set transform off player
        transform.rotation = enemy.rotation;
        transform.position = enemy.position + transform.forward * circleRadius;
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Rotate towards the enemy
        Vector3 lookDirection = enemy.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = rotation;

        if (isDashing)
        {
            // Lerp towards the target position
            float timeSpendPercentage = (Time.time - dashStartTime) / dashDuration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, timeSpendPercentage);

            if (timeSpendPercentage >= 1f)
            {
                isDashing = false;
            }
        }
    }

    public void OnDashLeft(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing)
        {
            currentDashAngle += dashAmountInAngles;
            Dash();
        }
    }

    public void OnDashRight(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing)
        {
            currentDashAngle -= dashAmountInAngles;
            Dash();
        }
    }

    private void Dash()
    {
        if (enemy)
        {
            targetPosition = enemy.position + Quaternion.Euler(0f, currentDashAngle, 0f) * Vector3.forward * circleRadius;
            dashStartTime = Time.time;
            isDashing = true;
            initialPosition = transform.position;
        }
    }
}
