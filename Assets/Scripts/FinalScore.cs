using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
    }


    public void SetFinalScore(int score)
    {
        scoreTxt.text = "Final score: " + score + "/5";
    }
}
