using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform enemy;
    public float dashSpeed = 5f;
    public float circleRadius = 13f;
    public float dashAmountInAngles = 22.5f;

    private float currentDashAngle = 0f;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isDashing = false;
    private float dashStartTime;
    private float dashDuration = 0.2f; // Needs beat sync!

    private void Start()
    {
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
            float t = (Time.time - dashStartTime) / dashDuration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            if (t >= 1f)
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
