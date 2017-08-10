using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    private ParticleSys ps;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSys>();
        ps.runSystem();
    }


}
