﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public string itemName;
    public string description;
    public float[] values;
    public string[] rambling;
    [SerializeField]
    float sizeNew = 1.2f;
    float sizeModifier = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
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
