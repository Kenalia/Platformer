using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Create a password system for access to Brain components. Only required if multiplayer is implemented.

public class Brain : MonoBehaviour {

	public MovementController moveControl;
	public CombatController combatControl;

    protected BoxCollider2D collider;
    protected Transform transform;
    protected Rigidbody2D rigidbody;


	void Start () {
        collider = GetComponentInChildren<BoxCollider2D>();
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update () {
        CheckMovementInputs();
	}

	protected virtual void CheckMovementInputs()
	{
		
	}

    virtual public BoxCollider2D AccessCollider()
    {
        return collider;
    }

    virtual public Transform AccessTransform()
    {
        return transform;
    }

    virtual public Rigidbody2D AccessRigidbody()
    {
        return rigidbody;
    }


}
