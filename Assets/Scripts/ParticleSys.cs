using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour {

    List<GameObject> particles = new List<GameObject>();
    bool start = false;
    Vector2 origin;

    public int x;
    public int y;
    public Vector2 force1;
    public Vector2 force2;
    public GameObject particle;

    // set origin in Start;
    private void Start()
    {
        origin = new Vector2(x, y);
    }

    // add a particle each update
    void Update()
    {
        if (start)
        {
            addParticle();
        }    
    }

    // apply wind force each update
    void FixedUpdate()
    {
        if (start)
        {
            checkIfAlive();
            if (Input.GetMouseButton(0))
            {
                applyGeneralForce(force1);
            }
            else if (Input.GetMouseButton(1))
            {
                applyGeneralForce(force2);
            }
        }
        
    }

    public List<GameObject> getParticles()
    {
        return particles;
    }
 

    // start running system
    public void runSystem()
    {
        start = true;
    }

    void checkIfAlive()
    {
        // list of particles to be removed
        List<GameObject> toBeRemoved = new List<GameObject>();
        // search particles for dead ones
        foreach (GameObject part in particles)
        {
            Particle particleClass = part.GetComponent<Particle>();
            // if dead, add to death list
            if (particleClass.Dead())
            {
                toBeRemoved.Add(part);
            }
        }
        // for each dead particle, remove it from particles, and destroy it
        foreach(GameObject removeMe in toBeRemoved)
        {
            bool removed = particles.Remove(removeMe);
            Destroy(removeMe);
        }
    }

    // apply force to all particles
    void applyGeneralForce(Vector2 force)
    {
        foreach (GameObject part in particles)
        {
                Rigidbody2D rb = part.GetComponent<Rigidbody2D>();
                rb.AddForce(force);
        }
    }

    // create new particle
    void addParticle()
    {
        // instantiate new particle
        GameObject newParticle = Instantiate(particle, origin, Quaternion.identity);
        // set a random initial velocity
        Rigidbody2D newParticleRB = newParticle.GetComponent<Rigidbody2D>();
        newParticleRB.velocity = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        // add it to our list of particles
        particles.Add(newParticle);
    }




}
