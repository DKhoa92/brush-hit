using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance{get; private set;}

    [SerializeField] Platform prefabPlatform;
    List<Platform> platformPool = new List<Platform>();

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    public Platform SpawnPlatform(Vector3 position, Transform parent)
    {
        Platform platform = null;
        for(int i=0;i<platformPool.Count;i++)
        {
            if(!platformPool[i].gameObject.activeSelf)
            {
                platform = platformPool[i];
                break;
            }
        }
 
        if(platform == null)
        {
            platform = Instantiate(prefabPlatform, position, Quaternion.identity, parent);
            platformPool.Add(platform);
        }
        platform.transform.position = position;
        platform.gameObject.SetActive(true);
        return platform;
    }

    public void SetActiveAll(bool status)
    {
        
        for(int i=0;i<platformPool.Count;i++)
        {
            platformPool[i].gameObject.SetActive(false);
        }
    }
}
