using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ManagerOfGame : MonoBehaviour
{

    [Tooltip("The scenery as background of the game")]
    [SerializeField]
    private GameObject gameScenery = null;


    [Tooltip("The base GameObject for all the dynamics objects")]
    [SerializeField]
    private GameObject dynamicObjectsBase = null;


    [Tooltip("The player to create when the game is starting")]
    [SerializeField]
    private GameObject playerShip = null;


    [Tooltip("The enemy ship to create during the game")]
    [SerializeField]
    private GameObject enemyShip = null;


    [Tooltip("The minimum time between two following spawning enemies")]
    [SerializeField]
    private float minTimeBeforeEnemySpawn = 1;


    [Tooltip("The maximum time between two following spawning enemies")]
    [SerializeField]
    private float maxTimeBeforeEnemySpawn = 3;


    [Tooltip("The minimum value possible to assign as reference position for a new enemy spawning")]
    [SerializeField]
    private float minYUnderZero = -8.3f;


    [Tooltip("The minimum value possible to assign as reference position for a new enemy spawning")]
    [SerializeField]
    private float maxYAboveZero = 8.3f;


    // Storing the base dynamic object once created, for enemy spawning in the good place of the hierarchy
    GameObject baseDynamicObjects;


    // The remaining time before the next enemy spawn
    private float remainingTimeBeforeEnemySpawn = 0f;
    
    
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
            baseDynamicObjects = Instantiate(dynamicObjectsBase);

            // Adding the player's ship
            Instantiate(playerShip, baseDynamicObjects.transform, true);

            IsGameOn = true;
        }
        else {
            if(remainingTimeBeforeEnemySpawn > 0) {
                remainingTimeBeforeEnemySpawn -= Time.deltaTime;
            }
            else {
                Instantiate(enemyShip, baseDynamicObjects.transform.position + new Vector3(0f, Random.Range(minYUnderZero, maxYAboveZero)),
                    baseDynamicObjects.transform.rotation, baseDynamicObjects.transform);

                // Resetting the counter using random
                remainingTimeBeforeEnemySpawn = Random.Range(minTimeBeforeEnemySpawn, maxTimeBeforeEnemySpawn);
            }
        }
    }
}
