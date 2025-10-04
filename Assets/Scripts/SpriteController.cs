using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    public void ChangeMood(DialogueObject dialogue)
    {
        Sprite newPortrait = sprites[4];
        switch (dialogue.Mood)
        {
            case (DialogueObject.Emotion.Happy):
                newPortrait = sprites[0];
                break;
            case (DialogueObject.Emotion.Sad):
                newPortrait = sprites[1];
                break;
            case (DialogueObject.Emotion.Angry):
                newPortrait = sprites[2];
                break;
            case (DialogueObject.Emotion.Disgust):
                newPortrait = sprites[3];
                break;
            case (DialogueObject.Emotion.Bored):
                newPortrait = sprites[4];
                break;
            default:
                Debug.LogError("Invalid name");
                break;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = newPortrait;
    } 

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
 }
