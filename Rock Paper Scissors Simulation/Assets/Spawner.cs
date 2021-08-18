using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] RPC;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedRPC;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start() {
       
    }

    // spawning a gameobject when it dies
    public void spawn(GameObject toSpawn) {
        if (toSpawn == RPC[0].gameObject) {
            Vector2 pos = toSpawn.transform.position;
            spawnedRPC = Instantiate(RPC[0]);
            spawnedRPC.transform.position = toSpawn.transform.position;
        } else if (toSpawn == RPC[1].gameObject) {
            Vector2 pos = toSpawn.transform.position;
            spawnedRPC = Instantiate(RPC[1]);
            spawnedRPC.transform.position = toSpawn.transform.position;
        } else if (toSpawn == RPC[2].gameObject) {
            Vector2 pos = toSpawn.transform.position;
            spawnedRPC = Instantiate(RPC[2]);
            spawnedRPC.transform.position = toSpawn.transform.position;
        } else {
            Debug.Log("This:" + RPC[0]);
        }
    }

    
}
