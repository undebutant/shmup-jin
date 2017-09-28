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


    private float elapsedTimeAfterShot = 0f;


    private void Update() {
        // Checking if the gun is on cooldown, and if so, decreasing it according to the elapsed time
        if(elapsedTimeAfterShot > 0) {
            elapsedTimeAfterShot -= Time.deltaTime;
        }
    }


    public bool Fire() {
        // Shooting a new bullet if the gun is not on cooldown
        if(elapsedTimeAfterShot <= 0) {
            Bullet newBullet = Instantiate(shotFired, transform.position, transform.rotation);
            newBullet.Init(BulletDamage, BulletSpeed);

            elapsedTimeAfterShot = BulletSpawnCooldown;

            return true;
        }

        return false;
    }
}
