using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCollision : MonoBehaviour {
    

    [SerializeField]
    private GameObject[] referenceRPC;

    private GameObject spawnRPC;

    private void OnTriggerEnter2D(Collider2D collision) { // if you win duplicate if you lose delete yourself
        /*spawnRPC = Instantiate(referenceRPC[0]); // cange to the correct one
        spawnRPC.transform.position = transform.position;*/
    }

}
