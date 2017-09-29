using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletType {
    player,
    enemy
}


public class BulletFactory : MonoBehaviour {

    [Tooltip("The prefab type of ammunition to create in the factory")]
    [SerializeField]
    private Bullet shotFiredEnemy;


    [Tooltip("The prefab type of ammunition to create in the factory")]
    [SerializeField]
    private Bullet shotFiredPlayer;


    // Defining the list to store unused bullets
    private List<Bullet> playerBulletStored;
    private List<Bullet> enemyBulletStored;


    private void Start() {
        playerBulletStored = new List<Bullet>();
        enemyBulletStored = new List<Bullet>();
    }


    private void CreateBullet(BulletType typeBulletToCreate) {
        Bullet newBulletCreated;

        switch (typeBulletToCreate) {
            case BulletType.player:
                // Creating a new player bullet
                newBulletCreated = Instantiate(shotFiredPlayer, transform.position, transform.rotation);

                // Storing the created bullet
                playerBulletStored.Add(newBulletCreated);
                break;

            case BulletType.enemy:
                // Creating a new enemy bullet
                newBulletCreated = Instantiate(shotFiredEnemy, transform.position, transform.rotation);

                // Storing the created bullet
                enemyBulletStored.Add(newBulletCreated);
                break;

            default:
                return;
        }
    }


    public Bullet SendBullet(float bulletDamage, Vector2 bulletSpeed, BulletType typeBulletToCreate, Vector3 position) {
        Bullet bulletToSend = null;

        switch (typeBulletToCreate){
            case BulletType.player:
                // If the storage is empty at the given moment
                if(playerBulletStored.Count == 0) {
                    CreateBullet(typeBulletToCreate);
                }

                // Popping the bullet from the storage
                bulletToSend = playerBulletStored[0];
                playerBulletStored.RemoveAt(0);

                // Initialize correctly the bullet
                bulletToSend.Init(bulletDamage, bulletSpeed, typeBulletToCreate, position);
                bulletToSend.gameObject.SetActive(true);

                return bulletToSend;
            
            case BulletType.enemy:
                // If the storage is empty at the given moment
                if (enemyBulletStored.Count == 0) {
                    CreateBullet(typeBulletToCreate);
                }

                // Popping the bullet from the storage
                bulletToSend = enemyBulletStored[0];
                enemyBulletStored.RemoveAt(0);

                // Initialize correctly the bullet
                bulletToSend.Init(bulletDamage, bulletSpeed, typeBulletToCreate, position);
                bulletToSend.gameObject.SetActive(true);

                return bulletToSend;
            
            default:
                return null;
        }
    }


    public void GetBulletBack(Bullet bulletToRecycle) {
        switch (bulletToRecycle.typeOfBullet) {
            case BulletType.player:
                // Resetting the position
                bulletToRecycle.transform.position = new Vector3(60f, 0f);

                // Storing the player bullet in the fitting list
                playerBulletStored.Add(bulletToRecycle);

                break;

            case BulletType.enemy:
                // Resetting the position
                bulletToRecycle.transform.position = new Vector3(60f, 0f);

                // Storing the player bullet in the fitting list
                enemyBulletStored.Add(bulletToRecycle);

                break;

            default:
                return;
        }
    }
}
