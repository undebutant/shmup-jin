using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletType typeOfBullet;


    // The damage inflicted by this bullet
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


    [Tooltip("The current speed of the bullet")]
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


    // Virtual function to update the position of the bullet
    public virtual void UpdatePosition() {}


    // Init method called on start
    public virtual void Init(float damage, Vector2 speed, BulletType typeBulletToInit, Vector3 startingPosition) {}
}
