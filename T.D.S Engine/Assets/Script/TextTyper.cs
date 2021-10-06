using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    private float speed;
    public float Speed => speed;
    
    private DialogueLine currentDialogueLine;
    public DialogueLine CurrentDialogueLine => currentDialogueLine;
    
    //gére le défilement du texte, prend en paramètre l'ui de texte, et une vitesse
    IEnumerator DisplayLine(DialogueLine dialogueBox,TextMeshProUGUI textDialogue, float speed)
    {
        textDialogue.text = "";
        foreach (char letter in dialogueBox.text.ToCharArray())
        {
            textDialogue.text += letter;
            yield return new WaitForSeconds(speed);
        }

        UIManager.Instance.onTextDisplayEnd();
    }
    
    //gère le commencement du text
    public void StartTyping(DialogueLine dialogueBox,TextMeshProUGUI textDialogue, float speed)
    {
        StartCoroutine(DisplayLine(dialogueBox,textDialogue, speed));
    }
    
    //gére le faite de skip le text
    public void EndTyping(DialogueLine dialogueBox,TextMeshProUGUI textDialogue)
    {
        StopCoroutine(DisplayLine(dialogueBox,textDialogue,speed));
        dialogueBox.text = currentDialogueLine.text;
    }
}
