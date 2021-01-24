using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public float fadeSpeed;
    [SerializeField]
    Animator cameraAnim;
    [SerializeField]
    Animator objectiveAnim;
    Animator canvasAnim;
    CanvasGroup cg;
    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        canvasAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        cg.interactable = false;
        cg.blocksRaycasts = false;
        canvasAnim.SetTrigger("startGame");
        objectiveAnim.SetTrigger("startGame");
        cameraAnim.SetTrigger("startGame");
    }
}
