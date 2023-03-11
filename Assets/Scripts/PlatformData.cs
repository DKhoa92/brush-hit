using UnityEngine;

public class PlatformData
{
    public bool isMoving;
    public float speed;
    public float distance;
    public int[,] design;
    public Vector3 initPosition;

    public PlatformData(bool isMoving, float speed, float distance, int[,] design, Vector3 initPosition)
    {
        this.isMoving = isMoving;
        this.speed = speed;
        this.distance = distance;
        this.design = design;
    }
}
