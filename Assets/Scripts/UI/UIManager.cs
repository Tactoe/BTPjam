using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject examineItemCanvas;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject finalScoreUI;
    [SerializeField]
    ShowcaseItem showcase;
    [SerializeField]
    GameObject showcaseCamera;
    GameObject lastObjectChecked;
    public bool inMenu = false;

    //Rest of your class code

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActivateItemCanvas(GameObject toShowcase, ItemData data)
    {
        inMenu = true;
        showcaseCamera.SetActive(true);
        examineItemCanvas.SetActive(true);
        lastObjectChecked = toShowcase;
        ValueHandler.Instance.PreviewValue(data.values);
        showcase.SetNewShowcase(toShowcase, data);
    }

    public void TurnOffItemCanvas()
    {
        inMenu = false;
        showcaseCamera.SetActive(false);
        examineItemCanvas.SetActive(false);
        ValueHandler.Instance.TogglePreview(false);
    }

    public void DitchObject()
    {
        ValueHandler.Instance.UpdateValues(lastObjectChecked.GetComponent<ItemData>().values);
        if (lastObjectChecked != null)
            Destroy(lastObjectChecked);
        TurnOffItemCanvas();
    }

    public void ShowFinalScore()
    {
        int score = 5 - ValueHandler.Instance.EvaluateIsland();
        finalScoreUI.SetActive(true);
        finalScoreUI.GetComponent<FinalScore>().SetFinalScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            Time.timeScale = pauseMenu.activeInHierarchy ? 0 : 1;
        }
    }
}
