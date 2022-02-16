using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public Rigidbody bulletPrefab;

   public bool debug = false;

   public void Fire() {
       if(debug) Debug.Log("Pow!");
       //create a copy of the bullet prefab
       Rigidbody bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
       // move the bullet infront of the gun.
       bullet.transform.Translate(0,0,1);
       // add forward force to the bullet.
       bullet.AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
   }
}
