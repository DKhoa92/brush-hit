using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleManager : MonoBehaviour
{
    public static CapsuleManager Instance{get; private set;}

    [SerializeField] Capsule prefabCapsule;
    List<Capsule> capsulePool = new List<Capsule>();
    int numberOfCapsule;
    int numberOfTriggeredCapsule;

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
        numberOfCapsule = 0;
        numberOfTriggeredCapsule = 0;
        capsulePool = new List<Capsule>();
    }


    void Update()
    {
        
    }

    public Capsule SpawnCapsule(Vector3 position, string firstColor, string secondColor)
    {
        Capsule capsule = null;
        numberOfCapsule++;
        for(int i=0;i<capsulePool.Count;i++)
        {
            if(!capsulePool[i].gameObject.activeSelf)
            {
                capsule = capsulePool[i];
                capsule.gameObject.SetActive(true);
                capsule.transform.position = position;
            }
        }
        if(capsule == null)
        {
            capsule = Instantiate(prefabCapsule, position, Quaternion.identity);
            capsulePool.Add(capsule);
        }
        capsule.firstColor = firstColor;
        capsule.secondColor = secondColor;
        return capsule;
    }


    public bool IsAllCapsuleTriggered()
    {
        return numberOfTriggeredCapsule==numberOfCapsule;
    }
}
