using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour {

    [Tooltip("The prefab type of ammunition shot by the bullet gun")]
    [SerializeField]
    private Bullet shotFired;


    // The damage inflicted by the bullet created by this gun
    [SerializeField]
    private float damageInflicted;

    public float BulletDamage
    {
        get {
            return this.damageInflicted;
        }

        set {
            this.damageInflicted = value;
        }
    }


    [Tooltip("The speed of the created bullet")]
    [SerializeField]
    private Vector2 speed;

    public Vector2 BulletSpeed
    {
        get {
            return this.speed;
        }

        set {
            this.speed = value;
        }
    }


    [Tooltip("The cooldown before spawning a new bullet")]
    [SerializeField]
    private float cooldown;

    public float BulletSpawnCooldown
    {
        get {
            return this.cooldown;
        }

        set {
            this.cooldown = value;
        }
    }


    private float remainingTimeAfterShot = 0f;


    // The energy variables
    float maxEnergy = 100f;
    float currentEnergy = 100f;
    float energyRegeneration = 30f;

    // Energy cost by shot
    float energyToShootInLine = 5f;

    // Used when the gun is too low on energy
    bool isShootingPossible = true;

    // The timer used to detect when the player isn't shooting
    float timeSinceLastBulletShot = 0f;

    // Energy UI manager script
    UIManager energyUIManager;


    private void Start() {
        currentEnergy = maxEnergy;
        energyUIManager = GameObject.FindWithTag("UI").GetComponent<UIManager>();

        // Updating the UI slider
        if (this.tag == "PlayerBulletSpawner") {
            energyUIManager.EnergySliderUpdater(currentEnergy / maxEnergy);
        }
    }


    private void Update() {
        timeSinceLastBulletShot += Time.deltaTime;

        // Checking if the gun is on cooldown, and if so, decreasing it according to the elapsed time
        if(remainingTimeAfterShot > 0) {
            remainingTimeAfterShot -= Time.deltaTime;
        }
        else {
            // Handling two different cases for enrgy regeneration
            if (timeSinceLastBulletShot > BulletSpawnCooldown) {
                if (isShootingPossible) {
                    currentEnergy = Mathf.Clamp(currentEnergy + energyRegeneration * Time.deltaTime, 0f, maxEnergy);
                }
                else {
                    currentEnergy = Mathf.Clamp(currentEnergy + energyRegeneration * Time.deltaTime * 0.75f, 0f, maxEnergy);
                }

                // Updating the UI slider
                if (this.tag == "PlayerBulletSpawner") {
                    energyUIManager.EnergySliderUpdater(currentEnergy / maxEnergy);
                }
            }
        }

        // Handling the case when the gun had no energy, and recharge fully
        if(currentEnergy == 100) {
            isShootingPossible = true;
        }
    }


    public bool Fire() {
        // Test if the gun is on cooldown because the energy was too low
        if (!isShootingPossible) {
            return false;
        }

        // Shooting a new bullet if the gun is not on cooldown
        if(remainingTimeAfterShot <= 0) {
            // Signaling that the player started shooting again
            timeSinceLastBulletShot = 0f;

            // Creating the bullet
            Bullet newBullet = Instantiate(shotFired, transform.position, transform.rotation);
            newBullet.Init(BulletDamage, BulletSpeed);

            // Resetting the timer to create a cooldown between shots
            remainingTimeAfterShot = BulletSpawnCooldown;

            // Decrementing the energy bar
            currentEnergy -= energyToShootInLine;

            // Checking if this last shot emptied the energy bar
            if(currentEnergy < 0) {
                isShootingPossible = false;
            }

            // Updating the UI slider
            if (this.tag == "PlayerBulletSpawner") {
                energyUIManager.EnergySliderUpdater(currentEnergy / maxEnergy);
            }

            return true;
        }

        return false;
    }
}
