using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    [SerializeField]
    GameObject examineItemCanvas;
    [SerializeField]
    ShowcaseItem showcase;
    [SerializeField]
    GameObject showcaseCamera;
    GameObject lastObjectChecked;
    public bool inMenu = false;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }

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
        showcase.SetNewShowcase(toShowcase, data);
    }

    public void TurnOffItemCanvas()
    {
        inMenu = false;
        showcaseCamera.SetActive(false);
        examineItemCanvas.SetActive(false);
    }

    public void DitchObject()
    {
        if (lastObjectChecked != null)
            Destroy(lastObjectChecked);
        TurnOffItemCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
