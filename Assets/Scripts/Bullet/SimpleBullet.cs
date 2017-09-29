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

    public override void Init(float damage, Vector2 speed, BulletType typeBulletToInit, Vector3 startingPosition) {
        BulletDamage = damage;
        BulletSpeed = speed;
        typeOfBullet = typeBulletToInit;
        transform.position = startingPosition;
    }

    void Update() {
        UpdatePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthManager>().TakeDamage(BulletDamage);
            GameObject.FindGameObjectWithTag("BulletFactory").GetComponent<BulletFactory>().GetBulletBack(this.gameObject);
        }
    }
}
