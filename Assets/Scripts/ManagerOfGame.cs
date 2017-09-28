using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ManagerOfGame : MonoBehaviour
{

    [Tooltip("The scenery as background of the game")]
    [SerializeField]
    private GameObject gameScenery;


    [Tooltip("The base GameObject for all the dynamics objects")]
    [SerializeField]
    private GameObject dynamicObjectsBase;


    [Tooltip("The player to create when the game is starting")]
    [SerializeField]
    private GameObject playerShip;


    // Defining a unique instance of the gameManager
    private static ManagerOfGame instance = null;

    // Using lock for thread-safety
    private static readonly object padlock = new object();

    public static ManagerOfGame GameManagerInstance {
        get {
            lock (padlock) {
                if (instance == null) {
                    instance = new ManagerOfGame();
                }
                return instance;
            }
        }
    }


    // The boolean defining whether or not a game is started
    private bool isGameOn;

    public bool IsGameOn {
        get {
            return this.isGameOn;
        }

        set {
            this.isGameOn = value;
        }
    }


    private void Start() {
        IsGameOn = false;
    }


    private void Update() {
        if (!IsGameOn) {
            // Creating the basic hierarchy of the project ingame
            Instantiate(gameScenery);
            GameObject baseDynamicObjects = Instantiate(dynamicObjectsBase);

            // Adding the player's ship
            Instantiate(playerShip, baseDynamicObjects.transform);

            IsGameOn = true;
        }
    }
}
