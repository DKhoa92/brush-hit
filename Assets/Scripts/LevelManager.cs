using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Level[] levels;
    int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = 0;
        levels = LevelDesign.ARR_LEVEL;
        StartLevel(currentLevelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLevel(int levelIndex)
    {
        Level level = levels[levelIndex];
        // CapsuleManager.Instance.SpawnCapsule()
        GenerateLevel(level);
    }

    public void NextLevel()
    {
        Debug.Log("LEVEL MANAGER: NextLevel");
        currentLevelIndex = ++currentLevelIndex % levels.Length;
        StartLevel(currentLevelIndex);
    }

    public void GameOver()
    {
        Debug.Log("LEVEL MANAGER: GameOver");
        StartLevel(currentLevelIndex);
    }

    void GenerateLevel(Level level)
    {
        foreach(Platform platform in level.platforms)
        {
            int[,] design = platform.design;
            for(int i=0; i<design.GetLength(0); i++)
            {
                for(int j=0; j<design.GetLength(1); j++)
                {
                    Debug.Log("i:"+i+", j:"+j);
                    if(design[i,j] == 1)
                    {
                        Debug.Log(CapsuleManager.Instance);
                        CapsuleManager.Instance.SpawnCapsule(new Vector3(i,0,j), level.firstColor, level.secondColor);
                    }
                }
            }
        }
    }
}
