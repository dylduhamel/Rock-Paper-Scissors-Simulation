using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    private List<Collider2D> triggerList = new List<Collider2D>();
    public List<Transform> transformTriggerList = new List<Transform>();

    // takes all of the objects that enter the sphere and add them to a list
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(!triggerList.Contains(collision)) {
            triggerList.Add(collision);
            transformTriggerList.Add(collision.transform);
        }
    }

    // remove the objects fro mthe list when they exit the sphere
    private void OnTriggerExit2D(Collider2D collision) {
        if(triggerList.Contains(collision)) {
            triggerList.Remove(collision);
            transformTriggerList.Remove(collision.transform);
        }
    }
}
