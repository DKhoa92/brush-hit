using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance{get; private set;}
    Level[] levels;
    int currentLevelIndex;
    int currentState;
    
    public const int STATE_INIT = 0;
    public const int STATE_START = 1;
    public const int STATE_PLAYING = 2;
    public const int STATE_OVER = 3;

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    void Start()
    {
        SetState(STATE_INIT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetState(int state)
    {
        currentState = state;
        switch(state)
        {
            case STATE_INIT:
                currentLevelIndex = 0;
                levels = LevelDesign.ARR_LEVEL;
                StartLevel(currentLevelIndex);
                break;
            case STATE_START:
                CapsuleManager.Instance.SetActiveAll(false);
                PlatformManager.Instance.SetActiveAll(false);
                ScoreManager.Instance.ResetScore();
                UIManager.Instance.UpdateLevelUI(levels[currentLevelIndex].level);
                break;
            case STATE_PLAYING:
                break;
            case STATE_OVER:
                break;
        }
    }

    public void StartLevel(int levelIndex)
    {
        SetState(STATE_START);
        Level level = levels[levelIndex];
        GenerateLevel(level);
    }

    public void NextLevel()
    {
        currentLevelIndex = ++currentLevelIndex % levels.Length;
        Debug.Log("LEVEL MANAGER: NextLevel"+currentLevelIndex);
        
        StartLevel(currentLevelIndex);
    }

    public void GameOver()
    {
        Debug.Log("LEVEL MANAGER: GameOver");
        SetState(STATE_OVER);
        StartLevel(currentLevelIndex);
    }

    void GenerateLevel(Level level)
    {
        for(int k=0; k<level.platforms.Length; k++)
        {
            Platform platformBlueprint = level.platforms[k];
            Platform platform = PlatformManager.Instance.SpawnPlatform(platformBlueprint.initPosition, transform);
            platform.UpdateData(platformBlueprint);
            level.platforms[k] = platform;
            int[,] design = platformBlueprint.design;
            for(int i=0; i<design.GetLength(0); i++)
            {
                for(int j=0; j<design.GetLength(1); j++)
                {
                    if(design[i,j] == 1)
                    {
                        CapsuleManager.Instance.SpawnCapsule(new Vector3(j,0,i), level.firstColor, level.secondColor, platform.transform);
                    }
                }
            }
        }
    }
}
