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

    void OnEnable()
    {
        // Debug.Log("SPAWN");
        _renderer = GetComponent<Renderer>();
        ChageColor(firstColor);
        isTriggered = false;
    }

    void Start() {
        ChageColor(firstColor);
    }
    void Update()
    {
        
    }

    private void ChageColor(string colorHex)
    {
        Debug.Log(colorHex);
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        _renderer.material.color = color;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerEnter");
        if(!isTriggered)
        {
            isTriggered = true;
            ChageColor(secondColor);
            CapsuleManager.Instance.numberOfTriggeredCapsule++;
            SoundManager.Instance.PlayPopSoundEffect();
            if(CapsuleManager.Instance.IsAllCapsuleTriggered())
                LevelManager.Instance.NextLevel();
        }
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerStay");
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerExit");
    }
}
