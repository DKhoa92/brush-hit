using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public bool isMoving;
    public float speed;
    public float distance;
    public int[,] design;
    public Vector3 initPosition;

    public Platform(int[,] design, bool isMoving, float speed, float distance, Vector3 initPosition)
    {
        this.design = design;
        this.isMoving = isMoving;
        this.speed = speed;
        this.distance = distance;
        this.initPosition = initPosition;
    }

    public void UpdateData(Platform platform)
    {
        this.design = platform.design;
        this.isMoving = platform.isMoving;
        this.speed = platform.speed;
        this.distance = platform.distance;
        this.initPosition = platform.initPosition;
    }
}
