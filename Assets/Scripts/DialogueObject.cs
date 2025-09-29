using UnityEditor;
using UnityEngine;
public class DialogueObject : ScriptableObject
{
    public enum Emotion
    {
        Happy,
        Sad,
        Angry,
        Disgust,
        Bored
    }

    public enum Person
    {
        You,
        Aiden,
        Narrator
    }
    [SerializeField] [TextArea] private string text;
    [SerializeField] private Person charName;
    [SerializeField] private Emotion mood;

    public string Text => text;

    public Person CharName => charName;
    public Emotion Mood => mood; 
}
