using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField]
    BoxCollider2D entityDetectionTrigger;

    LinkedList<PlatformBlock> blocks;
    LinkedListNode<PlatformBlock> leftBoundary;
    LinkedListNode<PlatformBlock> rightBoundary;

	void Start () {
        //blocks.AddFirst(leftBoundary);
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Handle_Enemy_Above(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Handle_Enemy_Below(collision.gameObject);
    }

    protected virtual void Handle_Enemy_Above(GameObject entity)
    {

    }

    protected virtual void Handle_Enemy_Below(GameObject entity)
    {

    }
}
