using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour {

    [Tooltip("The current speed of the enemy")]
    [SerializeField]
    private Vector2 enemySpeed = new Vector2(-0.4f, 0f);

    public Vector2 FoeSpeed {
        get {
            return this.enemySpeed;
        }

        set {
            this.enemySpeed = value;
        }
    }


    [Tooltip("The cooldown before spawning a new wave of bullets")]
    [SerializeField]
    private float cooldown;

    public float BulletWaveSpawnCooldown {
        get {
            return this.cooldown;
        }

        set {
            this.cooldown = value;
        }
    }


    // The time elapsed since the last wave of bullets
    private float elapsedTimeSinceWaveOfShots = 0f;


    [Tooltip("The number of shots in a raw to form a wave of bullets")]
    [SerializeField]
    private int numberOfShotsInWave = 3;


    // The number of shots remaining before ending the wave
    private int numberOfShotsRemainingInWave = 0;


    void Start() {
        GetComponent<Engines>().Speed = enemySpeed;
    }


    void Update () {
        // Checking if the wave is on cooldown, and if so, decreasing it according to the elapsed time
        if (elapsedTimeSinceWaveOfShots > 0) {
            elapsedTimeSinceWaveOfShots -= Time.deltaTime;
        }
        else {
            if(numberOfShotsRemainingInWave > 0) {
                if (GetComponentInChildren<BulletGun>().Fire()) {
                    numberOfShotsRemainingInWave -= 1;
                }
            }
            else {
                elapsedTimeSinceWaveOfShots = BulletWaveSpawnCooldown;
                numberOfShotsRemainingInWave = numberOfShotsInWave;
            }
        }
    }
}
