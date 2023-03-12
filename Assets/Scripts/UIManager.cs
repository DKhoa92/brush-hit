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
    [SerializeField] TextMeshProUGUI levelTextUI;
    [SerializeField] GameObject messageWinPopup;
    [SerializeField] GameObject messageLosePopup;

    public void UpdateScoreUI(int score)
    {
        scoreTextUI.text = score+"";
    }

    public void UpdateLevelUI(int level)
    {
        levelTextUI.text = level+"";
    }

    public void ShowWinPopup()
    {
        messageWinPopup.SetActive(true);
    }

    public void ShowLosePopup()
    {
        messageLosePopup.SetActive(true);
    }

    public void CloseMessagePopups()
    {
        messageWinPopup.SetActive(false);
        messageLosePopup.SetActive(false);
    }
}
