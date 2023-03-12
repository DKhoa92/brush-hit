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
    const string CAPSULE_IDLE_ANIM = "CapsuleIdleAnimation";
    const string CAPSULE_TILT_ANIM = "CapsuleTiltAnimation";
    const string CAPSULE_RECOVER_ANIM = "CapsuleRecoverAnimation";

    void OnEnable()
    {
        // Debug.Log("SPAWN");
        ChageColor(firstColor);
        ChangeParticleColor(secondColor);
        SetActiveParticle(false);
        isTriggered = false;
        GetComponent<Animator>().Play(CAPSULE_IDLE_ANIM);
    }

    void Start() {
        ChageColor(firstColor);
        ChangeParticleColor(secondColor);
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

    private void SetActiveParticle(bool status)
    {
        particle.SetActive(status);
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("CAPSULE: OnTriggerEnter");
        switch(GameManager.Instance.currentState)
        {
            case GameManager.State.INIT:
            case GameManager.State.GAME_OVER:
                break;
            case GameManager.State.READY:
                GetComponent<Animator>().Play(CAPSULE_TILT_ANIM);
                transform.LookAt(Player.Instance.transform);
                break;
            case GameManager.State.PLAYING:
                if(!isTriggered)
                {
                    isTriggered = true;
                    ChageColor(secondColor);
                    SetActiveParticle(true);
                    CapsuleManager.Instance.numberOfTriggeredCapsule++;
                    SoundManager.Instance.PlayPopSoundEffect();
                    ScoreManager.Instance.AddCapsuleScore();
                    if(CapsuleManager.Instance.IsAllCapsuleTriggered())
                        GameManager.Instance.Win();
                }
                GetComponent<Animator>().Play(CAPSULE_TILT_ANIM);
                transform.LookAt(Player.Instance.transform);
                break;
        }
    }

    private void OnTriggerStay(Collider other) {
        switch(GameManager.Instance.currentState)
        {
            case GameManager.State.INIT:
            case GameManager.State.GAME_OVER:
                break;
            case GameManager.State.READY:
                transform.LookAt(Player.Instance.transform);
                break;
            case GameManager.State.PLAYING:
                if(!isTriggered)
                {
                    isTriggered = true;
                    ChageColor(secondColor);
                    SetActiveParticle(true);
                    CapsuleManager.Instance.numberOfTriggeredCapsule++;
                    SoundManager.Instance.PlayPopSoundEffect();
                    ScoreManager.Instance.AddCapsuleScore();
                    transform.LookAt(Player.Instance.transform);
                    if(CapsuleManager.Instance.IsAllCapsuleTriggered())
                        GameManager.Instance.Win();
                }
                GetComponent<Animator>().Play(CAPSULE_TILT_ANIM);
                break;
        }
    }

    private void OnTriggerExit(Collider other) {
        switch(GameManager.Instance.currentState)
        {
            case GameManager.State.INIT:
                break;

            case GameManager.State.READY:
            case GameManager.State.PLAYING:
            case GameManager.State.GAME_OVER:
                GetComponent<Animator>().Play(CAPSULE_IDLE_ANIM);
                transform.rotation = Quaternion.identity;
                break;
        }
    }
}
