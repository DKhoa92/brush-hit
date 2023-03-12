using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] int activeCameraIndex;

    public static CameraController Instance{get; private set;}
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
        SwitchToCamera(activeCameraIndex);
    }

    public void SwitchCamera()
    {
        // Debug.Log("CAMERA CONTROLLER: SwitchCamera");
        activeCameraIndex = ++activeCameraIndex%cameras.Length;
        SwitchToCamera(activeCameraIndex);
    }

    public void ResetCamera()
    {
        activeCameraIndex = 0;
        SwitchToCamera(0);
    }

    void SwitchToCamera(int index)
    {
        cameras[index].Priority = 10;
        for(int i=0; i<cameras.Length; i++)
        {
            if(i!=activeCameraIndex)
                cameras[i].Priority = 1;
        }
    }

    void ResetAllPriority(int priority)
    {
        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = priority;
        }
    }
}
