using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public GameObject soundWave;
    public Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(!context.performed) return;

        GameObject currentSoundWave = Instantiate(soundWave, transform);
        currentSoundWave.GetComponent<SoundWaveProjectile>().targetTransform = enemyTransform;

        Renderer renderer = currentSoundWave.GetComponent<Renderer>();
        Material material = renderer.material;

        if(context.action.name == "AttackA"){
            material.color = Color.green;
            //Set Color to GREEN
            //Add GREEN to combo array
            //Play GREEN sound
            Debug.Log("Attack A?!");
            return;
        }

        if(context.action.name == "AttackB"){
            material.color = Color.red;
            //Set Color to RED
            //Add RED to combo array
            //Play RED sound
            Debug.Log("Attack B!");
            return;
        }

        if(context.action.name == "AttackX"){
            material.color = Color.blue;
            //Set Color to BLUE
            //Add BLUE to combo array
            //Play BLUE sound
            return;
        }

        if(context.action.name == "AttackY"){
            material.color = Color.yellow;
            //Set Color to YELLOW
            //Add YELLOW to combo array
            //Play YELLOW sound
            return;
        }
    }
}
