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
    [SerializeField]
    GameObject rateButton;
    GameObject rtGO;
    GameObject lastObjectChecked;
    public GameObject[] glist;
    public bool inMenu = false;
    public Dictionary<string, bool> activeMenus;
    public bool murderMode;

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
        rateButton.SetActive(false);
        lastObjectChecked = toShowcase;
        if (data.rambling != null && data.rambling.Length > 0)
        {
            RamblingText rt =  examineItemCanvas.GetComponentInChildren<RamblingText>(true);
            rt.currentRambling = data.rambling;
            rtGO.SetActive(true);
        }

        TeleportBehindYou tp = toShowcase.GetComponent<TeleportBehindYou>();
        if (tp != null)
            tp.canTeleport = true;

        if (!murderMode)
            ValueHandler.Instance.PreviewValue(data.values);
        showcase.SetNewShowcase(toShowcase, data);
    }

    public void TurnOffItemCanvas()
    {
        inMenu = false;
        showcaseCamera.SetActive(false);
        examineItemCanvas.SetActive(false);
        rateButton.SetActive(true);
        rtGO.SetActive(false);
        TeleportBehindYou tp = null;
        if (!murderMode)
        {
            ValueHandler.Instance.TogglePreview(false);
            tp = GameObject.Find("Anime Block").GetComponent<TeleportBehindYou>();
        }
        if (tp != null)
            tp.Teleport();
        
    }

    public void DitchObject()
    {
        //ValueHandler.Instance.UpdateValues(lastObjectChecked.GetComponent<ItemData>().values);
        if (lastObjectChecked != null)
        {
            lastObjectChecked.GetComponent<ItemData>().DitchObject();
            Destroy(lastObjectChecked);
        }
        glist = GameObject.FindGameObjectsWithTag("Erasable");
        print(GameObject.FindGameObjectsWithTag("Erasable").Length);

        if (GameObject.FindGameObjectsWithTag("Erasable").Length - 2 <= 0)
        {
            GameObject dio = GameObject.Find("DioramaSupport");
            dio.GetComponent<ItemData>().enabled = true;
            dio.tag = "Erasable";
            
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
