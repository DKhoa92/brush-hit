using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject part1;
    [SerializeField] GameObject part2;
    bool isOnCollision;
    GameObject pivotPart;
    float rotationSpeed;

    void Start()
    {
        Vector3 rotation = new Vector3(0, 10, 0);
        isOnCollision = false;
        pivotPart = part1;
        rotationSpeed = GameDefine.PLAYER_ROTATION_SPEED;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            // Debug.Log("PLAYER: Click Up");
            SwitchPart();
        }
        
        transform.RotateAround(pivotPart.transform.position, Vector3.up, rotationSpeed*Time.deltaTime);
    }

    void SwitchPart()
    {
        pivotPart = pivotPart == part1 ? part2 : part1;
        CameraController.Instance.SwitchCamera();
        rotationSpeed = -rotationSpeed;
    }

    public bool checkCollision()
    {
        return isOnCollision;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("PLAYER: OnTriggerEnter");
        isOnCollision = true;
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log("PLAYER: OnTriggerStay");
        isOnCollision = true;
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log("PLAYER: OnTriggerExit");
        isOnCollision = false;
    }
}
