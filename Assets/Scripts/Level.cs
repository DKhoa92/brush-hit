using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    Color firstColor;
    Color SecondColor;
    List<Platform> platforms;

    public void AddPlatform(Platform platform)
    {
        platforms.Add(platform);
    }
}
