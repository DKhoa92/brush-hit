using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public bool isMoving;
    public float speed;
    public float distance;
    public int[,] design;

    public Platform(int[,] design, bool isMoving, float speed, float distance)
    {
        this.design = design;
        this.isMoving = isMoving;
        this.speed = speed;
        this.distance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
