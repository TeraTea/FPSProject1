using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   // public variables
   public Rigidbody bulletPrefab;
   public Transform bulletSpawn;

   // attributes
   [Range(10,100)]
   public float bulletSpeed = 50;

   public bool debug = false;

   // private variables
   public int totalAmmo = 30;
   public int clipSize = 10;
   public int clip = 0;

   // 1. Allowed to burn our ammo by pressing R repeatedly.
   // 2. We lose the whole clip if we reload a partial clip

   
   
   
   public void Reload() {
       if (clip == clipSize) {
           if(debug) Debug.Log("Clip is already full.");
           return;
       }

       //int partialClip = 0;
       //if(clip > 0) partialClip = clip;


       if(totalAmmo + clip >= clipSize) {               // if 90 > 10
           totalAmmo -= (clipSize - clip);               // 90-10 = 80
           clip = clipSize;                     // clip = 10
       } else {
           // throw the rest of the ammo into the clip
           clip = totalAmmo + clip;
           totalAmmo = 0;

       }

       //totalAmmo += partialClip;
   }


   public void Fire() {
       if(debug) Debug.Log("Pow!");

       if(clip > 0) {
           clip -= 1;      
       //create a copy of the bullet prefab
       Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
       // move the bullet infront of the gun.
       bullet.transform.Translate(0,0,1);
       // add forward force to the bullet.
       bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        } else {
       if(debug) Debug.Log("Out of Ammo!");
        }
   }
}
