using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance{get; private set;}
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    int score;

    void Start() {
        score = 0;
    }

    public void AddScore(int score)
    {
        SetScore(this.score+score);
    }

    public void AddCapsuleScore()
    {
        AddScore(GameDefine.CAPSULE_SCORE);
    }

    public void ResetScore()
    {
        SetScore(0);
    }

    void SetScore(int score)
    {
        this.score = score;
        UIManager.Instance.UpdateScoreUI(score);
    }
    public int GetScore()
    {
        return score;
    }
}
