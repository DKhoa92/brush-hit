using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string firstColor;
    public string secondColor;
    public Platform[] platforms;
    public Vector3 playerStartPosition;

    public Level(string firstColor, string secondColor, Platform[] platforms, Vector3 playerStartPosition)
    {
        this.firstColor = firstColor;
        this.secondColor = secondColor;
        this.platforms = platforms;
        this.playerStartPosition = playerStartPosition;
    }
}
