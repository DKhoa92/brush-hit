using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int number;
    public string firstColor;
    public string secondColor;
    public Platform[] platforms;
    public Vector3 playerStartPosition;

    public Level(int number, string firstColor, string secondColor, Platform[] platforms, Vector3 playerStartPosition)
    {
        this.number = number;
        this.firstColor = firstColor;
        this.secondColor = secondColor;
        this.platforms = platforms;
        this.playerStartPosition = playerStartPosition;
    }
}
