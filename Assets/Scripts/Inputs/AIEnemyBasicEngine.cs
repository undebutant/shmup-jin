using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour {

    [Tooltip("The current speed of the enemy")]
    [SerializeField]
    private Vector2 enemySpeed = new Vector2(-0.4f, 0f);

    public Vector2 FoeSpeed {
        get {
            return this.enemySpeed;
        }

        set {
            this.enemySpeed = value;
        }
    }


    void Start() {
        GetComponent<Engines>().Speed = enemySpeed;
    }


    void Update () {

	}
}
