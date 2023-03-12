using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get; private set;}
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    [SerializeField] TextMeshProUGUI scoreTextUI;

    public void UpdateScoreUI(int score)
    {
        scoreTextUI.text = score+"";
    }

    public void UpdateLevelUI(int level)
    {
        
    }
}
