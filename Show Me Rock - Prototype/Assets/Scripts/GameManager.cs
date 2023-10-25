using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerTransform;
    public Transform enemyTransform;
    public int BPM;
    public int lanesCount = 16;
    [HideInInspector] public float laneAngle;
    public float arenaRadius = 13f;

    // Singleton instance
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        laneAngle = 360f / lanesCount;
    }

    private void OnDrawGizmos()
    {
        laneAngle = 360f / lanesCount;

        if (enemyTransform)
        {
            for (float angle = -180f; angle <= 180f; angle += laneAngle)
            {
                Vector3 targetPos = enemyTransform.position + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * arenaRadius;
                Gizmos.color = Color.red;
                Gizmos.DrawLine(enemyTransform.position, targetPos);
            }
        }
    }
}
