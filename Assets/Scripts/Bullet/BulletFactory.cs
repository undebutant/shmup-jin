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
    private GameObject shotFiredEnemy;


    [Tooltip("The prefab type of ammunition to create in the factory")]
    [SerializeField]
    private GameObject shotFiredPlayer;


    // Defining the list to store unused bullets
    private List<GameObject> playerBulletStored;
    private List<GameObject> enemyBulletStored;


    private void Start() {
        playerBulletStored = new List<GameObject>();
        enemyBulletStored = new List<GameObject>();
    }


    private void CreateBullet(BulletType typeBulletToCreate) {
        GameObject newBulletCreated;

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


    public void SendBullet(float bulletDamage, Vector2 bulletSpeed, BulletType typeBulletToCreate, Vector3 position) {
        GameObject bulletToSend = null;
        int sizeBulletList;

        switch (typeBulletToCreate){
            case BulletType.player:
                sizeBulletList = playerBulletStored.Count;

                // If the storage is empty at the given moment
                if (sizeBulletList == 0) {
                    CreateBullet(typeBulletToCreate);
                    sizeBulletList++;
                }

                // Popping the bullet from the storage
                bulletToSend = playerBulletStored[sizeBulletList - 1];
                playerBulletStored.RemoveAt(sizeBulletList - 1);

                // Initialize correctly the bullet
                bulletToSend.GetComponent<SimpleBullet>().Init(bulletDamage, bulletSpeed, typeBulletToCreate, position);
                bulletToSend.gameObject.SetActive(true);

                break;
            
            case BulletType.enemy:
                sizeBulletList = enemyBulletStored.Count;

                // If the storage is empty at the given moment
                if (sizeBulletList == 0) {
                    CreateBullet(typeBulletToCreate);
                    sizeBulletList++;
                }

                // Popping the bullet from the storage
                bulletToSend = enemyBulletStored[sizeBulletList - 1];
                enemyBulletStored.RemoveAt(sizeBulletList - 1);

                // Initialize correctly the bullet
                bulletToSend.GetComponent<SimpleBullet>().Init(bulletDamage, bulletSpeed, typeBulletToCreate, position);
                bulletToSend.gameObject.SetActive(true);

                break;
            
            default:
                return;
        }
    }


    public void GetBulletBack(GameObject bulletToRecycle) {
        switch (bulletToRecycle.GetComponent<SimpleBullet>().typeOfBullet) {
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
