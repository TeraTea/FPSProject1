// to do
// reset the platform after 10 seconds
// wait 2 seconds before it falls
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public float resetInterval = 3, hangTime = 2, resetTimer = 3;
    public AnimationCurve curve;

    public bool randomize = true;

    public Color startColor, waitColor, fallColor;
    //public Color startColor, waitColor, fallColor; any color we want

    Renderer rend;

    Vector3 startPosition;
    Rigidbody rb;
    Quaternion startRotation;


    bool platformIsActive = false;

    // Start is called before the first frame update
    void Start()
    {  
        if(randomize) {
           //randomize position slightly
           this.transform.Translate(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
       }

       rb = this.GetComponent<Rigidbody>(); 
       startPosition = this.transform.position;
       startRotation = this.transform.rotation;
       //rend.material.color = 
       rend = GetComponent<Renderer>();
       startColor = rend.material.color; 

       Randomize();
    }

    void Randomize() {
        if(randomize) {
           resetInterval += Random.Range(-resetInterval/3, resetInterval/3);
           hangTime += Random.Range(-hangTime/3, hangTime/3);
           resetTimer += Random.Range(-resetTimer/3, resetTimer/3);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name + " has run into us!");
        if(other.gameObject.CompareTag("Player")){
        StartCoroutine(WaitToFall());     // make the cube fall
        }
    }

//    void RandomColor() {
//       if(!platformIsActive) {
//           GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
//       }
//   }

//   void ResetColor() {
//           GetComponent<Renderer>().material.color = startColor;
//        }


    IEnumerator WaitToFall() {
        if(!platformIsActive){
        platformIsActive = true;
        rend.material.color = waitColor;
        yield return new WaitForSeconds(hangTime);
        rb.isKinematic = false;
        rend.material.color = fallColor;
        // call another coroutine that waits 8 seconds, then resets the platform
        StartCoroutine(ResetPlatform());
        }
    }

    IEnumerator ResetPlatform() {
        yield return new WaitForSeconds(resetTimer);
        //OLD WAY: this.transform.position = startPosition; 
        rb.isKinematic = true; // stop falling
        rend.material.color = waitColor;

        Vector3 pointB = startPosition;
        Vector3 pointA = this.transform.position;

        Quaternion rotA = this.transform.rotation;
        Quaternion rotB = startRotation;

        float timer = 0;

        while(timer < 1) {
            this.transform.position = Vector3.Lerp(pointA, pointB, curve.Evaluate(timer)); // position
            this.transform.rotation = Quaternion.Lerp(rotA, rotB, curve.Evaluate(timer)); // rotation
            rend.material.color = Color.Lerp(fallColor, startColor, curve.Evaluate(timer));
            timer += Time.deltaTime / resetInterval;
            yield return null;
        }

        // make it exact
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;

        Randomize();
        //platformIsActive = false;
        //ResetColor();
        rend.material.color = startColor;
        platformIsActive = false;

    }
}
