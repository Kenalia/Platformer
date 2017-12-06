using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    Brain brain;

	[SerializeField]
	private float speed = 5;
    [SerializeField]
    private float jumpForce = 8;
    [SerializeField]
    private float requiredDistanceFromGroundToJump = .05f;

    [SerializeField]
    private LayerMask platformLayer;

    Transform tr;
    Rigidbody2D rb;
    BoxCollider2D coll;

    [SerializeField]
    bool offGround = false;
    [SerializeField]
    bool canJump = true;
    [SerializeField]
    bool isSneaking = false;

    float jumpTimer = 0.0f;

    private Vector2 lastMoveVector;
    private Vector2 glidingVector = new Vector2(2.1933f, 1.0967f); //A scale of 1/9th 2:1 gravity


    private void FixedUpdate()
    {

        RaycastHit2D hit;
        if (tr != null)
        {
            hit = Physics2D.Raycast(tr.position, -tr.up, requiredDistanceFromGroundToJump, platformLayer);

            //Hit will detect the trigger colliders of the platforms, so an inner check must be made
            if (hit)
            {
                offGround = false;
            }
            else
            {
                offGround = true;
            }

            //Disable gravity when gliding
            if (isSneaking && offGround)
            {
                rb.gravityScale = 0.0f;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            else
            {
                rb.gravityScale = 1.0f;
            }

            if(jumpTimer > 0)
            {
                jumpTimer -= 0.1f;
            }
            else
            {
                jumpTimer = 0;
                canJump = true;
            }
        }
    }

    public void InitializeMovementController(Brain brain)
    {
        this.brain = brain;
        rb = brain.AccessRigidbody();
        tr = brain.AccessTransform();
        coll = brain.AccessCollider();
    }

	public void TakeMoveInput(Vector2 direction)
	{
        float tempSpeed = speed;

        if(isSneaking)
        {
            tempSpeed *= 0.2f;
        }

        //If isGlidng
        if(isSneaking && offGround)
        {
            if(direction == new Vector2(0,0))
            {
                //lastMoveVector stays the same, and gliding vector takes over
                tr.position += new Vector3(lastMoveVector.x * glidingVector.x, -glidingVector.y, 0) * Time.deltaTime;
            }
            //Apply new move vector to gliding vector
            else
            {
                lastMoveVector = direction;
                tr.position += new Vector3(direction.x * glidingVector.x, -glidingVector.y, 0) * Time.deltaTime;
            }
        }
        //Otherwise move normally
        else
        {
            lastMoveVector = direction;

            tr.position += new Vector3(direction.x * tempSpeed, direction.y * tempSpeed, 0) * Time.deltaTime;
        }
	}

    public void Jump()
    {
        if(canJump == true && offGround == false)
        {
            jumpTimer = 5.0f;

            rb.velocity = new Vector3(0, jumpForce, 0);

            canJump = false;
            offGround = true; //Keep the player from double jumping while the engine checks
        }
    }

    public void Sneak(bool newValue)
    {
        isSneaking = newValue;
        if(isSneaking && offGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    /// <summary>
    /// Sets the position to the passed Vector2
    /// </summary>
    /// <param name="newPosition">New Vector2 location to set</param>
    public void SetPosition(Vector2 newPosition)
    {
        tr.position = newPosition;
    }

    /// <summary>
    /// Sets the position of the object to (0,0)
    /// Base function for the SetPosition overloads
    /// </summary>
    public void SetPosition()
    {
        tr.position = new Vector2(0, 0);
    }

}
