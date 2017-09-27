using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Engines : MonoBehaviour {

    [Tooltip("The current speed of the avatar")]
    [SerializeField]
    private Vector2 enginesSpeed;

    public Vector2 Speed {
        get {
            return this.enginesSpeed;
        }

        set {
            this.enginesSpeed = value;
        }
    }

    // Defining an area where the player is supposed to stay
    [SerializeField]
    public float xmin, xmax, ymin, ymax;


    void Start () {

	}


	void Update () {
        // Evaluating the distance travelled by the avatar, then applying the altering speed coefficient
        float maxDistanceAvatar = this.GetComponentInParent<BaseAvatarProperties>().MaxSpeed * Time.deltaTime;

        // Moving the avatar, taking in account the boundaries of the playable area
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + enginesSpeed.x * maxDistanceAvatar, xmin, xmax),
            Mathf.Clamp(transform.position.y + enginesSpeed.y * maxDistanceAvatar, ymin, ymax),
            0f
            );
	}
}
