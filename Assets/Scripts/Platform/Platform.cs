using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField]
    BoxCollider2D entityDetectionTrigger;
    float triggerHeight = 2;

    public LinkedList<PlatformBlock> blocks;
    LinkedListNode<PlatformBlock> leftBoundary;
    LinkedListNode<PlatformBlock> rightBoundary;

	void Start () {
        blocks = new LinkedList<PlatformBlock>();
    }
	
	void Update () {
		
	}

    public void StartPlatform()
    {
        blocks = new LinkedList<PlatformBlock>();
    }

    public void PlatformFinished()
    {

        leftBoundary = blocks.First;
        rightBoundary = blocks.Last;


        entityDetectionTrigger = new BoxCollider2D();

        //float triggerOffset = (rightBoundary.Value.gameObject.transform.position.x + 1) - (leftBoundary.Value.gameObject.transform.position.x);

        //Y value of 0.5 because the collider needs to be in the middle, and the blocks are 1 unit tall, y is at bottom of unit
        //entityDetectionTrigger.offset = new Vector2(triggerOffset, 0.5f);
        //entityDetectionTrigger.size = new Vector2(blocks.Count, triggerHeight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Determine if collision happed above or below platform
        //Call proper function
    }

    protected virtual void Handle_Enemy_Above(GameObject entity, Vector2 collPoint)
    {
        //Find block at position
        //Call that block's Handle_Enemy_Above
    }

    protected virtual void Handle_Enemy_Below(GameObject entity, Vector2 collPoint)
    {
        //Find block at position
        //Call that block's Handle_Enemy_Below
    }
}
