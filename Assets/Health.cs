using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10;
    public AudioClip death;

    private AudioSource aud;

    [Tooltip("Check this box if this object is just an object, not an enemy.")]
    public bool isObject = false;

    void Start() {
        aud = this.gameObject.GetComponent<AudioSource>();
        aud.spatialBlend = 1;       // make sure the sound is positional.
    }

    //todo randomize starting health
    //regenerate health for enemies and player?
    //for objects, break objects into smaller pieces upon death
    //for death, use coroutine to make enemy smaller until death
    //for death, add rigidbody
    //for death, if enemy, give xp back to the player.

    void OnCollisionEnter(Collision other) {        // don't forget to tag your bullet
        if(other.gameObject.CompareTag("Bullet"))
        //health -= 2;        // let the bullet define that amount
        
        // let the velocity of the bullet define  that amount
        //Debug.Log("Magnitude: " + other.relativeVelocity.magnitude);
        //health -= (int)(other.relativeVelocity.magnitude * 0.05f);    


        // let the bullet define that amount
        health -= other.gameObject.GetComponent<Bullet>().damage;



        if(health <= 0) {
            Death();
        }
    
    }

    void Death() {
        if(isObject) {
            Destroy(this.GetComponent<Collider>());     // keep it from colliding with its parts
            Destroy(this.GetComponent<Renderer>());          //make it disappear
            for(int i = 0; i < 4; i++) {
                // randomize color of each part
                // have each part inherit bullet velocity
                // change the number of parts based on the size of the object.
                // have each part be randomly placed inside of the object, instead of centered.
                GameObject part = GameObject.CreatePrimitive(PrimitiveType.Cube);
                part.transform.localScale = Vector3.one * Random.Range(0.5f, 0.8f);
                part.transform.position = this.transform.position;
                part.transform.Translate(Random.Range(-.5f, .5f), Random.Range(-.5f, 5f), Random.Range(-.5f, 5f));
                part.AddComponent<Rigidbody>();
            }
            Destroy(this.gameObject, 1);
            aud.PlayOneShot(death);
        } else {
            this.gameObject.AddComponent<Rigidbody>(); // make enemy fall to death
            Destroy(this.gameObject, 5);    // destroy after 5 seconds

        }
    }

}

//Notes to look up later:
//CreatePrimitive
//Vector3.one
//AddComponent
//transform
