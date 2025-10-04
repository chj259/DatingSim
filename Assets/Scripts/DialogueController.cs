using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class DialogueController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text dialogueLabel;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text noteLabel;
    [SerializeField] private SceneObject sceneObject;
    [SerializeField] private GameObject portrait;
    private DialogueObject[] dialogues;
    private TypingEffect typingEffect;
    private Boolean isNarrator;
    private SpriteController portraitController;

    private void Start()
    {
        typingEffect = GetComponent<TypingEffect>();
        portraitController = portrait.GetComponent<SpriteController>();
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
            case DialogueObject.Person.GaiusVanBaelsar:
                return "Gaius Van Baelsar";
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
            portraitController.ChangeMood(dialogue);

            nameLabel.text = String.Empty;
            noteLabel.text = String.Empty;
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
            yield return typingEffect.Run(dialogue.Note, noteLabel,50);
            yield return new WaitUntil(() =>
                            Input.GetKeyDown(KeyCode.Space));
        }
    }

}
