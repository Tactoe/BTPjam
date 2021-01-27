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
    GameObject rtGO;
    GameObject lastObjectChecked;
    public bool inMenu = false;
    public Dictionary<string, bool> activeMenus;

    void Start()
    {
        RamblingText rt = examineItemCanvas.GetComponentInChildren<RamblingText>(true);
        rtGO = rt.gameObject;
        //activeMenus = new Dictionary<string, bool>();
        //foreach (GameObject child in GetComponentsInChildren<GameObject>())
        //{
        //    if (child.transform.parent != null)
        //    {
        //        activeMenus.Add(child.name, child.activeInHierarchy);
        //    }
        //}
    }

    public void ActivateItemCanvas(GameObject toShowcase, ItemData data)
    {
        inMenu = true;
        showcaseCamera.SetActive(true);
        examineItemCanvas.SetActive(true);
        lastObjectChecked = toShowcase;
        if (data.rambling != null && data.rambling.Length > 0)
        {
            RamblingText rt =  examineItemCanvas.GetComponentInChildren<RamblingText>(true);
            rt.currentRambling = data.rambling;
            rtGO.SetActive(true);
        }
        TeleportBehindYou tp = toShowcase.GetComponent<TeleportBehindYou>();
        if (tp != null)
        { 
            if (tp.canTeleport)
            {
                data.description = "You blinked, didn't you.";
            }
            tp.canTeleport = true;
        }
        ValueHandler.Instance.PreviewValue(data.values);
        showcase.SetNewShowcase(toShowcase, data);
    }

    public void TurnOffItemCanvas()
    {
        inMenu = false;
        showcaseCamera.SetActive(false);
        examineItemCanvas.SetActive(false);
        rtGO.SetActive(false);
        ValueHandler.Instance.TogglePreview(false);
        FindObjectOfType<TeleportBehindYou>().Teleport();
    }

    public void DitchObject()
    {
        ValueHandler.Instance.UpdateValues(lastObjectChecked.GetComponent<ItemData>().values);
        if (lastObjectChecked != null)
        {
            SpawnItemOnDeath deathSpawner = lastObjectChecked.GetComponent<SpawnItemOnDeath>();
            if (deathSpawner != null)
                deathSpawner.SpawnItems();
            Destroy(lastObjectChecked);
        }
        TurnOffItemCanvas();
    }

    public void ShowFinalScore()
    {
        inMenu = true;
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
