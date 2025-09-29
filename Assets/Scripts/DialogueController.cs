using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class DialogueController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text dialogueLabel;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private SceneObject sceneObject;
    private DialogueObject[] dialogues;
    private TypingEffect typingEffect;
    private Boolean isNarrator;

    private void Start()
    {
        typingEffect = GetComponent<TypingEffect>();
        dialogues = sceneObject.getDialogues();
        ShowDialogue(sceneObject);
    }

    private String GetName(DialogueObject dialogue)
    {
        isNarrator = false;
        switch (dialogue.CharName)
        {
            case DialogueObject.Person.You:
                return "You";
            case DialogueObject.Person.Aiden:
                return "Aiden";
            case DialogueObject.Person.Narrator:
                isNarrator = true;
                return String.Empty;
            default:
                Debug.LogError("Invalid name");
                return String.Empty;
        }
    }

    public void ShowDialogue(SceneObject sceneObject)
    {
        StartCoroutine(StepThroughDialogue(dialogues));
    }

    private IEnumerator StepThroughDialogue(DialogueObject[] dialogueObjects)
    {
        foreach (DialogueObject dialogue in dialogueObjects)
        {
            nameLabel.text = String.Empty;
            nameLabel.text = GetName(dialogue);
            //Debug.Log(isNarrator);
            
            String textToPrint = dialogue.Text;
            if (isNarrator)
            {
                dialogueLabel.fontStyle = FontStyles.Italic;
            }
            else
            {
                dialogueLabel.fontStyle = FontStyles.Normal;
            }

            yield return typingEffect.Run(textToPrint, dialogueLabel);

            yield return new WaitUntil(() =>
                            Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
        }
    }

}
