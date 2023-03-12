using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleManager : MonoBehaviour
{
    public static CapsuleManager Instance{get; private set;}

    [SerializeField] Capsule prefabCapsule;
    List<Capsule> capsulePool = new List<Capsule>();
    int numberOfCapsule =0;
    public int numberOfTriggeredCapsule;

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
        numberOfTriggeredCapsule = 0;
    }

    public void Reset()
    {
        numberOfCapsule = 0;
        numberOfTriggeredCapsule = 0;
        SetActiveAll(false);
    }

    public Capsule SpawnCapsule(Vector3 position, string firstColor, string secondColor, Transform parent)
    {
        Capsule capsule = null;
        numberOfCapsule++;
        for(int i=0;i<capsulePool.Count;i++)
        {
            if(!capsulePool[i].gameObject.activeSelf)
            {
                capsule = capsulePool[i];
                capsule.transform.position = position;
                break;
            }
        }
                
        if(capsule == null)
        {
            capsule = Instantiate(prefabCapsule, parent);
            capsulePool.Add(capsule);
        }
        capsule.firstColor = firstColor;
        capsule.secondColor = secondColor;
        capsule.transform.localPosition = position;
        capsule.gameObject.SetActive(true);
        return capsule;
    }

    public void SetActiveAll(bool status)
    {
        for(int i=0;i<capsulePool.Count;i++)
        {
            capsulePool[i].gameObject.SetActive(false);
        }
    }

    public bool IsAllCapsuleTriggered()
    {
        return numberOfTriggeredCapsule==numberOfCapsule;
    }
}
