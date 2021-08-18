using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    
    public int movementSpeed = 1;
    public float maxSpeed = 2;
    public float wanderStrength = 0.125f;
    public float steerStrength = 2;

    Vector2 screenBounds;
    Vector2 position;
    Vector2 velocity;
    Vector2 desiredDirection;

    // my link to the sphere child
    Sphere mySphere;

    // the list of enimies from the sphere function in my child
    List<Transform> listOfEnimiesNear;

    // what we set as the target
    Transform closestTarget;

    void Awake() {
        mySphere = gameObject.GetComponentInChildren<Sphere>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Start() {
        position = transform.position;
    }

    // Update is called once per frame
    void Update() {
        listOfEnimiesNear = mySphere.transformTriggerList;
        closestTarget = getClosestEnemy(listOfEnimiesNear, this.transform);
        moveToEnemy(closestTarget);
    }

    // loops through the list of enimies inside of the sphere and fints the closest
    Transform getClosestEnemy(List<Transform> enemies, Transform fromThis) {
        Transform bestTarget = null;
        float closestDistance = Mathf.Infinity;
        foreach (Transform potentialTarget in enemies) {
            if (potentialTarget.gameObject == null) {
                enemies.Remove(potentialTarget);
            } else if (Vector2.Distance(fromThis.position, potentialTarget.transform.position) < closestDistance) {
                closestDistance = Vector2.Distance(fromThis.position, potentialTarget.transform.position);
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    void moveToEnemy(Transform objectToMoveTo) {
        if (objectToMoveTo != null && objectToMoveTo.tag != this.tag) {
            desiredDirection = ((Vector2)objectToMoveTo.position - position).normalized;

            Vector2 desiredVelocity = desiredDirection * maxSpeed;
            Vector2 desiredSteeringForce = (desiredVelocity - velocity) * steerStrength;
            Vector2 acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;

            velocity = Vector2.ClampMagnitude(velocity + acceleration * Time.deltaTime, maxSpeed);
            position += velocity * Time.deltaTime;

            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation(position, Quaternion.Euler(0,0, angle));

        } else {

            if (position.x <= ((screenBounds.x * -1) + 1) || position.x >= (screenBounds.x - 1)) {
                desiredDirection = ((new Vector2(0f,0f) - position).normalized);
            } else if (position.y <= ((screenBounds.y * -1) + 1) || position.y >= (screenBounds.y) -1 ) {
                desiredDirection = ((new Vector2(0f, 0f) - position).normalized);
            } else {
                desiredDirection = (desiredDirection + Random.insideUnitCircle * wanderStrength).normalized;
            }
            Vector2 desiredVelocity = desiredDirection * maxSpeed;
            Vector2 desiredSteeringForce = (desiredVelocity - velocity) * steerStrength;
            Vector2 acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;

            velocity = Vector2.ClampMagnitude(velocity + acceleration * Time.deltaTime, maxSpeed);
            position += velocity * Time.deltaTime;

            

            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, angle));
        }
    }


}
