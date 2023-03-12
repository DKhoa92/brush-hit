using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPart : MonoBehaviour
{
    public bool isOnCollision;

    public void Reset() {
        isOnCollision = true;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("PART: OnTriggerEnter");
        switch(Player.Instance.currentState)
        {
            case Player.State.INIT:             
            case Player.State.SPAWN:
            case Player.State.DESPAWN:
                break;
            case Player.State.PLAYING:
                if(other.tag == "Capsule")
                    isOnCollision = true;
                break;
        } 
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("PART: OnTriggerStay");
        switch(Player.Instance.currentState)
        {
            case Player.State.INIT:             
            case Player.State.SPAWN:
            case Player.State.DESPAWN:
                break;
            case Player.State.PLAYING:
                if(other.tag == "Capsule")
                    isOnCollision = true;
                break;
        } 
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("PART: OnTriggerExit");
        switch(Player.Instance.currentState)
        {
            case Player.State.INIT:             
            case Player.State.SPAWN:
            case Player.State.DESPAWN:
                break;
            case Player.State.PLAYING:
                if(other.tag == "Capsule")
                    isOnCollision = false;
                break;
        } 
    }
}
