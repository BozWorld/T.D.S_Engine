using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine

{
    public DialogueType type =  DialogueType.Dialogue;
    [Multiline] public string text = "";
    public bool activeEffect;
    public bool isCharacterTalking;
    public int nextLineIndex = 0;
    public int characterSpriteIdx;
    public List<Choice> choices;
    public enum DialogueType{   Dialogue = 0, Choice = 1, GoodEnd = 2, BadEnd = 3}
}

[System.Serializable]
public struct Choice
{
    public string choiceDialogue;
    public int choiceidx;
}
