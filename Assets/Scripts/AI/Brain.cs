using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

	public MovementController moveControl;
	public CombatController combatControl;


	void Start () {
		CheckMovementInputs();
	}

	void Update () {
		
	}

	protected virtual void CheckMovementInputs()
	{
		
	}
}
