using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

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

    [SerializeField]
    bool offGround = false;
    [SerializeField]
    bool jumped = false;
    [SerializeField]
    bool isSneaking = false;

    private Vector2 lastMoveVector;
    private Vector2 glidingVector = new Vector2(2.1933f, 1.0967f); //A scale of 1/9th 2:1 gravity


    private void FixedUpdate()
    {

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, requiredDistanceFromGroundToJump, platformLayer);

        //Hit will detect the trigger colliders of the platforms, so an inner check must be made
        if (hit)
        {
            Debug.LogFormat("In range of floor: {0}", (transform.position.y - (GetComponent<BoxCollider2D>().size.y)) <= hit.collider.transform.position.y + requiredDistanceFromGroundToJump);

            //Ensure that player is actually on the platform
            if ((transform.position.y - (GetComponent<BoxCollider2D>().size.y)) <= hit.collider.transform.position.y + requiredDistanceFromGroundToJump)
            {

                offGround = false;
                jumped = false;
            }
        }
        else
        {
            offGround = true;
        }

        //Disable gravity when gliding
        if (isSneaking && offGround)
        {
            rb.gravityScale = 0.0f;
        }
        else
        {
            rb.gravityScale = 1.0f;
        }
    }

    public void InitializeMovementController()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
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
        if(jumped == false)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);

            jumped = true;
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

}
