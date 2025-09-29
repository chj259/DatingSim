using UnityEngine;

[CreateAssetMenu(menuName = "Scene/SceneObject")]
public class SceneObject : ScriptableObject
{
    [SerializeField] DialogueObject[] dialogues;

    public DialogueObject[] getDialogues()
    {
        DialogueObject[] d = new DialogueObject[dialogues.Length];
        dialogues.CopyTo(d, 0);
        return d;
    }
}
