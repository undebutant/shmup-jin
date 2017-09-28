using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

    public override void UpdatePosition() {
        // Calculating the travelled distance since the last frame
        Vector3 newMovement = new Vector3(
            Time.deltaTime * BulletSpeed.x,
            Time.deltaTime * BulletSpeed.y,
            0f
            );

        transform.position += newMovement;
    }

    public override void Init(float damage, Vector2 speed) {
        BulletDamage = damage;
        BulletSpeed = speed;
    }

    void Update() {
        UpdatePosition();

        // Destroy the bullet whenever the sprite goes outside the playable area
        if (transform.position.x < 0 || transform.position.x > 40) {
            Destroy(this.gameObject);
        }
        else if (!GetComponent<SpriteRenderer>().enabled) {
            Destroy(this.gameObject);
        }
    }
}
