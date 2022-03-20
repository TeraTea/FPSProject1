using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Gun gun; // should this route through the playercontroller? perhaps...

    public bool debug = false;

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if(mouse == null) return;


        if(mouse.leftButton.isPressed) {
            if(debug) Debug.Log("Left Mouse Button was pressed this frame.");

            if(gun != null) {
                gun.Fire(); // calling the fire method of the gun variable.
            } else {
                if(debug) Debug.Log("There is no gun to fire!");
            }
        }
        
        var keyboard = Keyboard.current;
        if(keyboard == null) return;

        if(keyboard.rKey.wasPressedThisFrame){
            if(gun != null) {
                gun.Reload();
            }
        }
        // restart game
        if(keyboard.digit7Key.wasPressedThisFrame) {
            Application.LoadLevel(0);
        }
        // pause game
        if(keyboard.digit8Key.wasPressedThisFrame) {
            if(Time.timeScale == 1) {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
        }
        // quit game
        if(keyboard.digit9Key.wasPressedThisFrame) {
            Application.Quit(0);
        }
        // mute game
        if(keyboard.digit0Key.wasPressedThisFrame) {
            if(AudioListener.volume == 1) {
                AudioListener.volume = 0;
            } else {
                AudioListener.volume = 1;
            }
        }

        //how to use multi-key presses.
        if(keyboard.leftCtrlKey.isPressed) {
            if(keyboard.qKey.wasPressedThisFrame) {
                Application.Quit();
            }
        }
    }
}
