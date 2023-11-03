using SonicBloom.Koreo;
using UnityEngine;

public class KoreograherToShoot : MonoBehaviour
{
    [EventID]
    public string eventID;
    private EnemyCombat enemy;
    
    void Start()
    {
        Koreographer.Instance.RegisterForEventsWithTime(eventID, TriggerShootEvent);
        enemy = gameObject.GetComponent<EnemyCombat>();
    }

    void TriggerShootEvent(KoreographyEvent evt, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        enemy.Attack();
    }
}
