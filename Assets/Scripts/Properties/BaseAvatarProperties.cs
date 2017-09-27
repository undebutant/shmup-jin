using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseAvatarProperties : MonoBehaviour {
    [SerializeField]
    private float maximumSpeed;

    public float MaxSpeed {
        get {
            return this.maximumSpeed;
        }

        private set {
            this.maximumSpeed = value;
        }
    }
}
