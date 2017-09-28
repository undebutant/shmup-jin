using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

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
    public virtual void Init(float damage, Vector2 speed) {}


    void Update() {
        UpdatePosition();

        // Destroy the bullet whenever the sprite goes outside the playable area
        if (transform.position.x < 0 || transform.position.y > 40) {
            Destroy(this.gameObject);
        }
        else if(!GetComponent<SpriteRenderer>().enabled) {
            Destroy(this.gameObject);
        }
    }
}
