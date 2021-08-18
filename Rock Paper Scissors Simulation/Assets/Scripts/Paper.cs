using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour {

    // reference to the spaener
    public Spawner s;

    // class for paper
    Enemy paper;

    // Start is called before the first frame update
    void Awake() {
        paper = new Enemy("paper", "rock", "scissors");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(paper.whoILose)) {
            gameObject.active = false;
        } else if (collision.gameObject.CompareTag(paper.whoIBeat)) {
            Debug.Log(this.gameObject);
            s.spawn(this.gameObject);
        }
    }
}
