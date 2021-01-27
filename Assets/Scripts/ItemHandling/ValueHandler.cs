﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueHandler : MonoBehaviour
{
    [SerializeField]
    GameObject meterPrefab;
    public static ValueHandler Instance;
    public float[] values;
    public float[] idealValues;
    public Color[] jaugeColors;
    List<Image> positivePreview;
    List<Image> negativePreview;
    List<Image> negativePreviewCover;
    List<Image> jauges;
    List<Image> goalIndicators;

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
        positivePreview = new List<Image>();
        negativePreview = new List<Image>();
        negativePreviewCover = new List<Image>();
        jauges = new List<Image>();
        goalIndicators = new List<Image>();

        SetupLevel();
        TogglePreview(false);
    }

    void SetupLevel()
    {
        for (int i = 0; i < values.Length; i++)
        {
            GameObject tmp = Instantiate(meterPrefab, transform);
            jauges.Add(tmp.transform.Find("Jauge").GetComponent<Image>());
            positivePreview.Add(tmp.transform.Find("Positive").GetComponent<Image>());
            jauges[i].color = jaugeColors[i];

            Transform negativeHolder = tmp.transform.Find("NegativeBar");
            negativePreview.Add(negativeHolder.Find("Negative").GetComponent<Image>());
            negativePreviewCover.Add(negativeHolder.Find("Cover").GetComponent<Image>());
            negativePreviewCover[i].color = jaugeColors[i];

            goalIndicators.Add(tmp.transform.Find("Indicator").GetComponent<Image>());
            goalIndicators[i].rectTransform.rotation = Quaternion.Euler(0, 0, -90 - (idealValues[i] / 100) * 360);
        }
        SetValues();
    }

    public void UpdateValues(float[] newValues)
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Mathf.Clamp(values[i] + newValues[i], 0, 100);
        }
        SetValues();
        TogglePreview(false);
    }

    void SetValues()
    {
        for (int i = 0; i < values.Length; i++)
        {
            jauges[i].fillAmount = values[i] / 100;
        }
    }

    public void PreviewValue(float[] newValues)
    {
        //TogglePreview(true);
        for (int i = 0; i < values.Length; i++)
        {
            if (newValues[i] > 0)
            {
                positivePreview[i].gameObject.SetActive(true);
                positivePreview[i].fillAmount = (values[i] + newValues[i]) / 100;
            }
            else if (newValues[i] < 0)
            {
                negativePreview[i].gameObject.SetActive(true);
                negativePreview[i].fillAmount = (values[i]) / 100;
                negativePreviewCover[i].gameObject.SetActive(true);
                negativePreviewCover[i].fillAmount = (values[i] + newValues[i]) / 100;
            }
        }
    }

    public void TogglePreview(bool status)
    {
        for (int i = 0; i < positivePreview.Count; i++)
        {
            positivePreview[i].gameObject.SetActive(status);
            negativePreview[i].gameObject.SetActive(status);
            negativePreviewCover[i].gameObject.SetActive(status);
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
        return Mathf.RoundToInt(surplus / (values.Length * 100 / 5));
    }
}
