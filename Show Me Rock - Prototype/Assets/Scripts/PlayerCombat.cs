using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    //Needs to be restricted to only be able to attack on beat

    
    public GameObject playerSoundWave;

    //Assinged from start
    private Transform enemyTransform;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        enemyTransform = GameManager.Instance.enemyTransform;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(playerMovement.isDashing) return;
        if(!context.performed) return;

        GameObject currentSoundWave = Instantiate(playerSoundWave, transform.position, transform.rotation);

        Renderer renderer = currentSoundWave.GetComponent<Renderer>();
        Material material = renderer.material;

        if(context.action.name == "AttackA"){
            material.color = Color.green;
            return;
        }

        if(context.action.name == "AttackB"){
            material.color = Color.red;
            return;
        }

        if(context.action.name == "AttackX"){
            material.color = Color.blue;
            return;
        }

        if(context.action.name == "AttackY"){
            material.color = Color.yellow;
            return;
        }
    }
}
