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
    
    public float sizeModifier = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Erasable";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
