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
}
