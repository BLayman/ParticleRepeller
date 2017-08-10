using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    public int lifespan;
    bool dead = false;

    void Update () {
        lifespan -= 2;
        if (lifespan < 0)
        {
            dead = true;
        }
	}

    public bool Dead()
    {
        return dead;
    }


}
