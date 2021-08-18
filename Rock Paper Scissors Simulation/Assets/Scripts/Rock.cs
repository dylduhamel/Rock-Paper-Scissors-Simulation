using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    // reference to the spaener
    public Spawner sp;

    // class for rock
    Enemy rock;

    // Start is called before the first frame update
    void Awake() {
        rock = new Enemy("rock", "scissors", "paper");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(rock.whoILose)) {
            gameObject.active = false;
        } else if (collision.gameObject.CompareTag(rock.whoIBeat)) {
            sp.spawn(this.gameObject);
        }
    }
}
