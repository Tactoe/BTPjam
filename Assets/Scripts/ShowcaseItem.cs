using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowcaseItem : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject[] prefabs;
    public Transform spawnLocation;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI descriptionText;


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
        descriptionText.text = data.description;
        currentShowcase = Instantiate(newShowcase, spawnLocation);
        currentShowcase.transform.rotation = Quaternion.Euler(Vector3.zero);
        currentShowcase.layer = 5;
        currentShowcase.AddComponent<RotateItem>();
        currentShowcase.transform.position = spawnLocation.transform.position;
    }
}
