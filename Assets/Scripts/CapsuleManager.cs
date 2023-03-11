using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleManager : MonoBehaviour
{
    public static CapsuleManager Instance{get; private set;}

    [SerializeField] Capsule prefabCapsule;
    Capsule[] capsulePool;

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
        
    }


    void Update()
    {
        
    }

    public Capsule GenerateCapsule(Vector3 position)
    {
        for(int i=0;i<capsulePool.Length;i++)
        {
            if(!capsulePool[i].gameObject.activeSelf)
            {
                return capsulePool[i];
            }
        }
        return Instantiate(prefabCapsule, position, Quaternion.identity);
    }
}
