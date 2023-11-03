using SonicBloom.Koreo;
using UnityEngine;

public class KoreographerToPulse : MonoBehaviour
{
    [EventID]
    public string eventID;
    private SoundWaveProjectile projectile;
    
    void Start()
    {
        Koreographer.Instance.RegisterForEventsWithTime(eventID, TriggerPulseEvent);
        projectile = gameObject.GetComponent<SoundWaveProjectile>();
    }

    void TriggerPulseEvent(KoreographyEvent evt, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        projectile.Pulse();
    }

}
