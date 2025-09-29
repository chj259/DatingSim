using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text dialogueLabel;
    [SerializeField] private SceneObject sceneObject;
    private DialogueObject[] dialogues;
    private TypingEffect typingEffect;

    private void Start()
    {
        typingEffect = GetComponent<TypingEffect>();
        dialogues = sceneObject.getDialogues();
        ShowDialogue(sceneObject);
    }

    public void ShowDialogue(SceneObject sceneObject)
    {
        StartCoroutine(StepThroughDialogue(dialogues));
    }

    private IEnumerator StepThroughDialogue(DialogueObject[] dialogueObjects)
    {
        foreach (DialogueObject dialogue in dialogueObjects)
        {
            yield return typingEffect.Run(dialogue.Text, dialogueLabel);
        }
    }

}
