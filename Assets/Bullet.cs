using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 2;

    // option to randomize bullet damage?
    void Start() {
        if(Random.value < 0.8f) {            // 80% chance
            damage *= 2;
            Debug.Log("Double Damage!");
        }
    }
    

    // option to make "critical hit" bullet damage?
}
