using UnityEngine;

[CreateAssetMenu(menuName = "Scene/SceneObject")]
public class SceneObject : ScriptableObject
{
    public DialogueObject[] dialogues;

    public DialogueObject[] getDialogues()
    {
        DialogueObject[] d = new DialogueObject[dialogues.Length];
        dialogues.CopyTo(d, 0);
        return d;
    }
}

[System.Serializable]
public class DialogueObject
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
        GaiusVanBaelsar,
        Narrator
    }
    [TextArea][SerializeField] private string text;
    [SerializeField] private string note;
    [SerializeField] private Person charName;
    [SerializeField] private Emotion mood;

    public string Text => text;
    public string Note => note;
    public Person CharName => charName;
    public Emotion Mood => mood;
}
