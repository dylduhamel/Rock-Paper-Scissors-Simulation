using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Scissors : MonoBehaviour {

    // reference to the spaener
    public Spawner sp;

    // class for scissors
    Enemy scissors;

    void Awake() {
        scissors = new Enemy("scissors", "paper", "rock");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(scissors.whoILose)) {
            gameObject.active = false;
        } 
        else if (collision.gameObject.CompareTag(scissors.whoIBeat)) {
            sp.spawn(this.gameObject);
        }
    }
}
    
