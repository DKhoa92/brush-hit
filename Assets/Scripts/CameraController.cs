using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
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

    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] int activeCameraIndex;
    CinemachineBasicMultiChannelPerlin cinemachineBMCP;
    float shakeTime;
    bool isShaking;
    [SerializeField] float SHAKE_TIME = 0.2f;
    
    void Start()
    {
        shakeTime = 0;
        SwitchToCamera(activeCameraIndex);
        cinemachineBMCP = cameras[activeCameraIndex].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if(isShaking)
        {
            if(shakeTime>0)
                shakeTime -= Time.deltaTime;
            else{
                StopShake();
                isShaking = false;
            }
        }
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

    public void ShakeCamera()
    {
        isShaking = true;
        shakeTime = SHAKE_TIME;
        cinemachineBMCP.m_AmplitudeGain = 4;
        cinemachineBMCP.m_FrequencyGain = 5;
    }

    void StopShake()
    {
        cinemachineBMCP.m_AmplitudeGain = 0;
        cinemachineBMCP.m_FrequencyGain = 0;
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
