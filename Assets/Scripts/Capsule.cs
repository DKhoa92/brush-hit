using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public string firstColor;
    public string secondColor;
    [SerializeField] GameObject particle;
    [SerializeField] Renderer _renderer;
    bool isTriggered;
    // Start is called before the first frame update

    void OnEnable()
    {
        // Debug.Log("SPAWN");
        ChageColor(firstColor);
        ChangeParticleColor(secondColor);
        SetActiveParticle(false);
        isTriggered = false;
    }

    void Start() {
        ChageColor(firstColor);
        ChangeParticleColor(secondColor);
    }
    void Update()
    {
        
    }

    private void ChageColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        _renderer.material.color = color;
    }

    private void ChangeParticleColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        ParticleSystem.MainModule main = particle.GetComponent<ParticleSystem>().main;
        main.startColor = color;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerEnter");
        if(!isTriggered)
        {
            isTriggered = true;
            ChageColor(secondColor);
            SetActiveParticle(true);
            CapsuleManager.Instance.numberOfTriggeredCapsule++;
            SoundManager.Instance.PlayPopSoundEffect();
            ScoreManager.Instance.AddCapsuleScore();
            if(CapsuleManager.Instance.IsAllCapsuleTriggered())
                LevelManager.Instance.NextLevel();
        }
    }

    private void SetActiveParticle(bool status)
    {
        particle.SetActive(status);
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerStay");
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerExit");
    }
}
