using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueReader : MonoBehaviour
{
    Dialogue currentDialogue;
    DialogueNode currentNode;
    [SerializeField]
    Image leftCharacter, rightCharacter, bgImg;
    [SerializeField]
    TextMeshProUGUI nameText, dialogueText;
    [SerializeField]
    CanvasGroup cg;
    int dialogueIndex;
    // Start is called before the first frame update
    void Start()
    {
        cg.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialogueIndex < currentDialogue.dialogue.Count)
            {
                ReadNewNode(currentDialogue.dialogue[dialogueIndex]);
            }
            else
            {
                CloseDialogue();
            }
        }
    }

    public void StartDialogue(Dialogue newDial)
    {
        currentDialogue = newDial;
        ReadNewNode(currentDialogue.dialogue[dialogueIndex]);
        cg.alpha = 1;
    }

    void ReadNewNode(DialogueNode node)
    {
        if (node.text != "")
        {
            dialogueText.transform.parent.gameObject.SetActive(true);
            dialogueText.text = node.text;
        }
        else
            dialogueText.transform.parent.gameObject.SetActive(false);
        if (node.speakerName != "")
        {
            Color color;
            nameText.transform.parent.gameObject.SetActive(true);
            nameText.text = node.speakerName;
            if (node.speakerName == "Maro")
                nameText.transform.parent.GetComponent<Image>().color = new Color(22, 0, 27);
            if (node.speakerName == "Cubotron")
                nameText.transform.parent.GetComponent<Image>().color = new Color(252, 228, 182);
        }
        else
            nameText.transform.parent.gameObject.SetActive(false);
        HandleImg(node.img, bgImg);
        HandleImg(node.leftSpeaker, leftCharacter);
        HandleImg(node.rightSpeaker, rightCharacter);
        dialogueIndex++;
        print(dialogueIndex);
    }

    void HandleImg(Sprite img, Image target)
    {
        if (img != null)
        {
            target.sprite = img;
            target.gameObject.SetActive(true);
        }
        else
            target.gameObject.SetActive(false);
    }

    void CloseDialogue()
    {
        GameManager.Instance.NextScene();
        cg.alpha = 0;
    }
}
