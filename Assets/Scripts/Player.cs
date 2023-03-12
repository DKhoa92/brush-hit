using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance{get; private set;}
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    [SerializeField] GameObject part1;
    [SerializeField] GameObject part2;
    [SerializeField] TrailRenderer[] trails;
    bool isOnCollision;
    GameObject pivotPart;
    float rotationSpeed;
    State currentState;

    public enum State
    {
        INIT = 0,
        SPAWN = 1,
        READY_TO_PLAY = 2,
        PLAYING = 3,
        DESPAWN = 4,
    }
    const string PLAYER_IDLE_ANIM = "PlayerIdleAnimation";
    const string PLAYER_SPAWN_ANIM = "PlayerSpawnAnimation";
    const string PLAYER_DESPAWN_ANIM = "PlayerDespawnAnimation";


    public void Init()
    {
        SetState(State.INIT);
    }

    public void Spawn(Vector3 position)
    {
        transform.position = position;
        SetState(State.SPAWN);
    }

    public void Despawn()
    {
        SetState(State.DESPAWN);
    }

    public void Play()
    {
        SetState(State.PLAYING);
    }

    void SetState(State state)
    {
        // Debug.Log("PLAYER STATE:"+state);
        currentState = state;
        switch(state)
        {
            case State.INIT:
                Vector3 rotation = new Vector3(0, 10, 0);
                isOnCollision = true;
                rotationSpeed = GameDefine.PLAYER_ROTATION_SPEED;
                GetComponent<Animator>().Play(PLAYER_IDLE_ANIM);
                break;
            case State.SPAWN:
                pivotPart = part1;
                CameraController.Instance.ResetCamera();
                GetComponent<Animator>().Play(PLAYER_SPAWN_ANIM);
                break;
            case State.PLAYING:
                break;
            case State.DESPAWN:
                GetComponent<Animator>().Play(PLAYER_DESPAWN_ANIM);
                break;
        }
    } 

    void Update()
    {
        switch(currentState)
        {
            case State.INIT:             
            case State.SPAWN:
            case State.DESPAWN:
                break;

            case State.READY_TO_PLAY:
                transform.RotateAround(pivotPart.transform.position, Vector3.up, rotationSpeed*Time.deltaTime);
                break;

            case State.PLAYING:
                if(Input.GetMouseButtonUp(0))
                {
                    // Debug.Log("PLAYER: Click Up");
                    SwitchPart();
                }
                transform.RotateAround(pivotPart.transform.position, Vector3.up, rotationSpeed*Time.deltaTime);
                break;
        }
    }

    void OnAnimationSpawnEnd()
    {
        SetState(State.READY_TO_PLAY);
        foreach (TrailRenderer trail in trails)
        {
            trail.gameObject.SetActive(true);
        }
    }

    void OnAnimationDespawnEnd()
    {
        if(GameManager.Instance.currentState == GameManager.State.WIN)
            UIManager.Instance.ShowWinPopup();
        else
            UIManager.Instance.ShowLosePopup();
    }

    void SwitchPart()
    {
        pivotPart = pivotPart == part1 ? part2 : part1;
        CameraController.Instance.SwitchCamera();
        rotationSpeed = -rotationSpeed;
        if(!IsOnCollision())
            GameManager.Instance.GameOver();
    }

    public bool IsOnCollision()
    {
        return isOnCollision;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("PLAYER: OnTriggerEnter");
        switch(currentState)
        {
            case State.INIT:             
            case State.SPAWN:
            case State.DESPAWN:
                break;
            case State.PLAYING:
                isOnCollision = true;
                break;
        } 
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("PLAYER: OnTriggerStay");
        switch(currentState)
        {
            case State.INIT:             
            case State.SPAWN:
            case State.DESPAWN:
                break;
            case State.PLAYING:
                isOnCollision = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("PLAYER: OnTriggerExit");
        switch(currentState)
        {
            case State.INIT:             
            case State.SPAWN:
            case State.DESPAWN:
                break;
            case State.PLAYING:
                isOnCollision = false;
                break;
        }
    }
}
