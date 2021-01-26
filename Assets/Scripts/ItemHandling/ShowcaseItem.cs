using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowcaseItem : MonoBehaviour
{
    public Transform spawnLocation;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI ramblingNameText;
    [SerializeField]
    TextMeshProUGUI descriptionText;
    [SerializeField]
    Camera uiCam;

    GameObject currentShowcase;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame


    public void SetNewShowcase(GameObject newShowcase, ItemData data)
    {
        if (currentShowcase != null)
            Destroy(currentShowcase);
        nameText.text = data.itemName;
        ramblingNameText.text = data.itemName;
        //uiCam.orthographicSize = data.getSizeMod();
        setSize(newShowcase.transform.localScale);
        descriptionText.text = data.description;
        currentShowcase = setupObjectShowcase(newShowcase);
    }

    GameObject setupObjectShowcase(GameObject obj)
    {
        GameObject ret = Instantiate(obj, spawnLocation);
        SetAllChildUI(ret);
        ret.layer = 5;
        ret.AddComponent<RotateItem>();
        ret.transform.position = spawnLocation.transform.position;
        ret.transform.rotation = Quaternion.Euler(Vector3.left * 10);
        return ret;
    }

    void SetAllChildUI(GameObject ret)
    {
        for (int i = 0; i < ret.transform.childCount; i++)
        {
            ret.transform.GetChild(i).gameObject.layer = 5;
            if (ret.transform.childCount > 0)
            {
                SetAllChildUI(ret.transform.GetChild(i).gameObject);
            }
        }
    }

    void setSize(Vector3 scale)
    {
        uiCam.orthographicSize = Mathf.Max(scale.x, scale.y, scale.z);
        if (scale.x == scale.y && scale.x == scale.z)
            uiCam.orthographicSize += 0.08f;
    }
}
