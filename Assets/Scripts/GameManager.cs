using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    public State currentState;
    public enum State{
        INIT = 0,
        READY = 1,
        PLAYING = 2,
        WIN = 3,
        GAME_OVER = 4
    }

    void Start()
    {
        SetState(State.INIT);
    }

    void Update()
    {
        switch(currentState)
        {
            case State.INIT:
                break;
            case State.READY:
                if(Input.GetMouseButtonDown(0))
                {
                    // Debug.Log("GAME MANAGER: Click Down");
                    SetState(State.PLAYING);
                }
                break;
            case State.PLAYING:
                break;
            case State.GAME_OVER:
                break;
        }
    }

    void SetState(State state)
    {
        currentState = state;
        switch(state)
        {
            case State.INIT:
                LevelManager.Instance.Init();
                Player.Instance.Init();
                LevelManager.Instance.SetupLevel(LevelManager.LevelNumber.LEVEL1);
                SetState(State.READY);
                break;
            case State.READY:
                break;
            case State.PLAYING:
                Player.Instance.Play();
                break;
            case State.WIN:
                Player.Instance.Despawn();
                break;
            case State.GAME_OVER:
                Player.Instance.Despawn();
                break;
        }
    }

    public void Win()
    {
        SetState(State.WIN);
    }

    public void GameOver()
    {
        SetState(State.GAME_OVER);
        CameraController.Instance.ShakeCamera();
    }

    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();
        SetState(State.READY);
    }

    public void Replay()
    {
        LevelManager.Instance.Restart();
        SetState(State.READY);
    }
}
