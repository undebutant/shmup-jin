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


    public virtual void UpdatePosition() {
        // Calculating the travelled distance since the last frame
        Vector3 newMovement = new Vector3(
            Time.deltaTime * BulletSpeed.x,
            Time.deltaTime * BulletSpeed.y,
            0f
            );

        transform.position += newMovement;
    }


    public virtual void Init() {
        BulletDamage = 0f;
        BulletSpeed = new Vector2(0f, 0f);
    }


    void Update() {
        UpdatePosition();

        // Whenever the sprite hit something and is no longer seeable
        if (!GetComponent<SpriteRenderer>().isVisible) {
            Destroy(this.gameObject);
        }
    }
}
