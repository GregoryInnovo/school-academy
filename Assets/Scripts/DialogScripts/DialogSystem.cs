using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!didDialogueStart) {
                StartDialogue();
            } else if(dialogueText.text == dialogueLines[lineIndex]) {
                NextDialogueLine();
            } else {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }   
    }

    private IEnumerator ShowLine() {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]) {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        } 

    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length) {
            StartCoroutine(ShowLine());
        } else {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
        }
    }
}
