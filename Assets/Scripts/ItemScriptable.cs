using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item Data")]
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public string description;
    public GameObject model;
    public float[] values;
    public string[] rambling;
}
