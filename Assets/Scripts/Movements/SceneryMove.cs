using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneryMove : MonoBehaviour {

    [Tooltip("The moving speed for the background")]
    public float scrollSpeed = 10;

    [Tooltip("The length of the moving background tile")]
    public float lengthTile;

    // The initial position of this tile, before any scrolling
    private Vector3 startPosition;

    // The current X position of the tile
    private float currentPositionX = 0f;


    void Start () {
        startPosition = transform.position;
	}


	void Update () {
        // Making the background sliding and coming back to initial position to have infinite loop
        float newPosition = Mathf.Repeat(currentPositionX + Time.deltaTime * scrollSpeed, lengthTile);
        currentPositionX = newPosition;

        transform.position = startPosition + Vector3.left * newPosition;
	}
}
