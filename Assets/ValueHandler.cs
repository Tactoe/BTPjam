using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueHandler : MonoBehaviour
{
    public static ValueHandler Instance;
    public float[] values;
    public float[] idealValues;
    [SerializeField]
    Image[] jauges;

    void Awake()
    {

        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }


    void Start()
    {
        SetValues();
    }

    void Update()
    {
        
    }

    public void UpdateValues(float[] newValues)
    {
        for (int i = 0; i < newValues.Length; i++)
        {
            values[i] = Mathf.Clamp(values[i] + newValues[i], 0, 100);
        }
        SetValues();
    }

    void SetValues()
    {
        for (int i = 0; i < values.Length; i++)
        {
            jauges[i].fillAmount = values[i] / 100;
        }
    }

    public int EvaluateIsland()
    {
        float surplus = 0;
        for (int i = 0; i < values.Length; i++)
        {
            surplus += Mathf.Abs(values[i] - idealValues[i]);
        }
        print(surplus);
        surplus -= surplus > 20 ? 20 : 0; 
        return Mathf.RoundToInt(surplus / 70);
    }
}
