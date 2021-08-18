using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {

    private string _name;
    private string _whoIBeat;
    private string _whoILose;
    
    public Enemy(string name, string whoIBeat, string whoILose) {
        this._name = name;
        this._whoIBeat = whoIBeat;
        this._whoILose = whoILose;
    }

    public string name {
        get { return name; }
        set { name = value; }
    }

    public string whoIBeat {
        get { return _whoIBeat; }
        set { _whoIBeat = value; }
    }

    public string whoILose {
        get { return _whoILose; }
        set { _whoILose = value; }
    }


}


