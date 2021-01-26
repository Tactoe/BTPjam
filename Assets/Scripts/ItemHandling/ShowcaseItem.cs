using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowcaseItem : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform spawnLocation;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI descriptionText;
    Camera uiCam;

    GameObject currentShowcase;
    // Start is called before the first frame update
    void Start()
    {
        uiCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame


    public void SetNewShowcase(GameObject newShowcase, ItemData data)
    {
        if (currentShowcase != null)
            Destroy(currentShowcase);
        nameText.text = data.itemName;
        //uiCam.orthographicSize = data.getSizeMod();
        setSize(newShowcase.transform.localScale);
        descriptionText.text = data.description;
        currentShowcase = Instantiate(newShowcase, spawnLocation);
        currentShowcase.layer = 5;
        currentShowcase.AddComponent<RotateItem>();
        currentShowcase.transform.position = spawnLocation.transform.position;
        currentShowcase.transform.rotation = Quaternion.Euler(Vector3.left * 10);
    }

    void setSize(Vector3 scale)
    {
        uiCam.orthographicSize = Mathf.Max(scale.x, scale.y, scale.z);
    }
}
