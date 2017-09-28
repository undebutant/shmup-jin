using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour {

    // Defining the player GameObject to look for when starting a new game
    private GameObject playerShip = null;


    void Start () {
        playerShip = GameObject.FindWithTag("Player");
	}


	void Update () {
        // Fetching the input movement of the player
        Vector2 playerMovements = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );

        // Handling the diagonal case, to keep a constant speed whatever the direction
        if (playerMovements.x != 0 && playerMovements.y != 0) {
            playerMovements /= 1.4142f;
        }

        
        // Fetching shot swap input from the player
        bool isPlayerSwappingWeapon = Input.GetButtonDown("Fire2");


        // Calling fitting methods of the ship to send the player's commands
        if(playerShip != null) {
            // Handling movement of the player's ship
            playerShip.GetComponent<Engines>().Speed = playerMovements;

            // Handling shoots from the player
            if (Input.GetButton("Fire1")) {
                playerShip.GetComponentInChildren<BulletGun>().Fire();
            }
        }
    }
}
