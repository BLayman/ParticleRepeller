using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repell : MonoBehaviour {

    List<GameObject> particles;
    GameObject particleSystemObject;
    public float scalar;

	void Start () {
        particleSystemObject = GameObject.FindWithTag("ParticleSystem");
        // get particles from the particle system
        ParticleSys psys = particleSystemObject.GetComponent<ParticleSys>();
        particles = psys.getParticles();
	}
	
	void FixedUpdate () {
        //Debug.Log("count " + particles.Count);
        if (particles.Count != 0)
        {
            foreach (GameObject part in particles)
            {
                // calculate distance and direction of particle to repeller to create repell force
                Vector2 forceDirection = transform.position - part.transform.position;
                float distance = forceDirection.magnitude;
                forceDirection.Normalize();
                //Debug.Log("distance: " + distance);
                float forceMag = (-1 * scalar) / (distance * distance);
                //Debug.Log("force mag: " + forceMag);

                // apply repell force to particle
                Rigidbody2D partRB = part.GetComponent<Rigidbody2D>();
                partRB.AddForce(forceDirection * forceMag);
            }
        }
        
	}
}
