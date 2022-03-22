using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagWin : MonoBehaviour
{
    public AudioClip flagWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        AudioSource.PlayClipAtPoint(flagWin, transform.position);
        Destroy(gameObject);
    }
}
