using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundManager : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Bullet"))
        {
            // Disabling the bullet, then recycling it
            collision.gameObject.SetActive(false);

            GameObject.FindGameObjectWithTag("BulletFactory").GetComponent<BulletFactory>().GetBulletBack(collision.gameObject);
        }
        else {
            Destroy(collision.gameObject);
        }
    }
}
