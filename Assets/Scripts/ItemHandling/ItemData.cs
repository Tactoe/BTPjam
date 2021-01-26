using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public string itemName;
    [TextArea(5, 6)]
    public string description;
    public float[] values;
    [TextArea(5, 10)]
    public string[] rambling;
    [SerializeField]
    float sizeNew = 1.2f;
    float sizeModifier = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Erasable";
    }

    public float getSizeMod()
    {
        return sizeNew > sizeModifier ? sizeNew : sizeModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
