using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public string firstColor;
    public string secondColor;
    Renderer _renderer;
    bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        isTriggered = false;
        ChageColor(firstColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChageColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        _renderer.material.color = color;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerEnter");
        isTriggered = true;
        ChageColor(secondColor);
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerStay");
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerExit");
    }
}
