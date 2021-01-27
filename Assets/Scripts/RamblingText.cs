using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RamblingText : MonoBehaviour
{
    public GameObject ramblingTextbox;
    public string[] currentRambling;

    int ramblingIndex = 0;
    TextMeshProUGUI rambling;
    bool isTalking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateRambling();
        }
    }

    void UpdateRambling()
    {
        if (isTalking)
        {
            if (ramblingIndex + 1 < currentRambling.Length)
            {
                ramblingIndex++;
                rambling.text = currentRambling[ramblingIndex];
            }
            else
            {
                CloseRambling();
            }
        }
        else
        {
            isTalking = true;
            rambling = ramblingTextbox.GetComponentInChildren<TextMeshProUGUI>();
            rambling.text = currentRambling[ramblingIndex];
            ramblingTextbox.SetActive(true);
        }
    }

    void CloseRambling()
    {
        isTalking = false;
        ramblingIndex = 0;
        //currentRambling = new string[0];
        rambling.text = "";
        ramblingTextbox.SetActive(false);

    }
}
