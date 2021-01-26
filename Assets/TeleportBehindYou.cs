using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehindYou : MonoBehaviour
{
    public GameObject positionParent;
    List<Transform> positions;
    public bool canTeleport;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Transform>();
        Transform[] tmpPositions = positionParent.GetComponentsInChildren<Transform>(true);
        foreach (Transform p in tmpPositions)
        {
            if (p.transform.childCount == 0)
            {
                positions.Add(p);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Teleport()
    {
        if (canTeleport)
        {
            int index = Random.Range(0, positions.Count);
            print(index);
            transform.position = positions[index].position;
        }

    }
}
