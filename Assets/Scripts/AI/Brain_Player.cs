using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_Player : Brain {

    private void Start()
    {
        if(moveControl == null)
        {
            moveControl = GetComponent<MovementController>();
        }
        
        if(combatControl == null)
        {
            combatControl = GetComponent<CombatController>();
        }

        moveControl.InitializeMovementController();
    }

    private void Update()
    {
        CheckMovementInputs();
    }

    protected override void CheckMovementInputs()
    {

        Vector2 direction = new Vector2(0, 0);
        if (Input.GetKey(InputManager.IM.ctrl_moveRight))
        {
            direction.x += 1;
        }

        if (Input.GetKey(InputManager.IM.ctrl_moveLeft))
        {
            direction.x -= 1;
        }

        if (Input.GetKey(InputManager.IM.ctrl_moveDown))
        {
            
        }

        moveControl.TakeMoveInput(direction);

        if(Input.GetKeyDown(InputManager.IM.ctrl_jump))
        {
            moveControl.Jump();
        }

        if(Input.GetKeyDown(InputManager.IM.ctrl_sneak))
        {
            moveControl.Sneak(true);
        }
        else if(Input.GetKeyUp(InputManager.IM.ctrl_sneak))
        {
            moveControl.Sneak(false);
        }
    }

}
