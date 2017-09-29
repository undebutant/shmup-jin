using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    [SerializeField]
    private float maxHealth;

    public float MaxHealth
    {
        get {
            return this.maxHealth;
        }

        private set {
            this.maxHealth = value;
        }
    }


    [SerializeField]
    private float currentHealth;

    public float Health
    {
        get {
            return this.currentHealth;
        }

        private set {
            this.currentHealth = value;
        }
    }


    // Health UI manager script
    [SerializeField]
    UIManager healthUIManager;


    public void TakeDamage(float damageTaken) {
        Health -= damageTaken;

        // Updating the UI slider
        if (this.tag == "Player") {
            healthUIManager.HealthSliderUpdater(currentHealth / maxHealth);
        }

        if (Health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(this.gameObject);
    }


    void Start() {
        Health = MaxHealth;
        healthUIManager = GameObject.FindWithTag("UI").GetComponent<UIManager>();

        // Updating the UI slider
        if (this.tag == "Player") {
            healthUIManager.HealthSliderUpdater(currentHealth / maxHealth);
        }
    }
}
