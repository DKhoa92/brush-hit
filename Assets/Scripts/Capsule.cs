using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    Color firstColor;
    Color secondColor;
    Renderer _renderer;
    bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChageColor()
    {
        _renderer.material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerEnter");
        ChageColor();
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerStay");
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerExit");
    }
}
