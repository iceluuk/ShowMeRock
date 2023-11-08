using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float flashDuration;

    // mesh renderer that should flash
    private MeshRenderer meshRenderer;

    private Material originalMaterial;
    private Coroutine flashRoutine;

    private bool flashUp;
    private bool flashDown;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        meshRenderer.material = flashMaterial;
        meshRenderer.material.SetVector("_EmissionColor", Color.white * 5f);

        if (flashUp)
        {
            // gradually increase intensity, up to a roof, then flash down..
            {
                flashUp = false;
                flashDown = true;
            }
        }

        if (flashDown)
        {
            // gradually decrease, until done, then end
            {
                flashDown = false;
                flashRoutine = null;
            }
        }

        yield return new WaitForSeconds(flashDuration);

        meshRenderer.material = originalMaterial;

    }
        
}
