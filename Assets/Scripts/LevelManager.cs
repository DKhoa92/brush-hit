using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance{get; private set;}
    Level[] levels;
    LevelNumber currentLevel;
    State currentState;
    
    public enum LevelNumber{
        LEVEL1=0,
        LEVEL2=1,
        LEVEL3=2,
    }

    public enum State{
        INIT,
        READY,
    }

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    void SetState(State state)
    {
        currentState = state;
        switch(state)
        {
            case State.INIT:
                currentLevel = 0;
                levels = LevelDesign.ARR_LEVEL;
                break;
            case State.READY:
                Level level = levels[(int)currentLevel];
                CapsuleManager.Instance.Reset();
                PlatformManager.Instance.SetActiveAll(false);
                ScoreManager.Instance.ResetScore();
                UIManager.Instance.UpdateLevelUI(level.number);
                Player.Instance.Spawn(level.playerStartPosition);
                GenerateLevel(level);
                break;
        }
    }

    public void Init()
    {
        SetState(State.INIT);
    }

    public void SetupLevel(LevelNumber level)
    {
        currentLevel = level;
        SetState(State.READY);
    }

    public void NextLevel()
    {
        int nextLevel = ((int)currentLevel+1) % levels.Length;
        currentLevel = (LevelNumber) nextLevel;
        // Debug.Log("LEVEL MANAGER: NextLevel"+currentLevel);
        SetupLevel(currentLevel);
    }

    public void Restart()
    {
        SetupLevel(currentLevel);
    }

    void GenerateLevel(Level level)
    {
        // Debug.Log("LEVEL MANAGER: Generate");
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
