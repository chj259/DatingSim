using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    public enum Mood
    {
        Happy,
        Sad,
        Angry,
        Disgust,
        Neutral
    }
    [SerializeField][TextArea] private string text;
    [SerializeField] private Mood mood;

    public string Text => text;
}
