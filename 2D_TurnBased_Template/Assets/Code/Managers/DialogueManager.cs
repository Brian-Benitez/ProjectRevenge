using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject UIDialogueCanvas;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public bool IsDialogueInProgress = false;

    public float TypingSpeed;
    private float _normalTypingSpeed = .5f;

    public int SentencesCount = 0;

    private void Awake()
    {
        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        TurnOnDialogueUI();
        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.DialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        SentencesCount++;
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            IsDialogueInProgress = true;
            dialogueArea.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
        }

        IsDialogueInProgress = false;
        //TypingSpeed = _normalTypingSpeed;//work in progress..
    }

    public void TurnOnDialogueUI() => UIDialogueCanvas.SetActive(true);
    public void TurnOffDialogueUI()
    {
        UIDialogueCanvas.SetActive(false);
    }
    void EndDialogue()
    {
        isDialogueActive = false;
        UIDialogueCanvas.SetActive(false);
        //animator.Play("hide");
    }
}
