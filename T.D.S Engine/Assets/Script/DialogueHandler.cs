using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public int  currentDialogueIdx;
    public static DialogueHandler Instance;
   [SerializeField] [Range(0, 20)] private float typingSpeed;

   void Awake ()
   {
       if (Instance == null)
           Instance = this;
       else
           Destroy (gameObject);
   }
   
   public void OnDialogueLineEnd()
   {
       List<DialogueLine> dialogueList = UIManager.Instance.characterInfo.dialogueList;
       
   }

   public void startDialogue(CharacterInfo characterInfo)
   {
       UIManager.Instance.dialogueBoxText.text = "";
       this.characterInfo = characterInfo;
       currentDialogueIdx = 0;
       UIManager.Instance.canvas.SetActive(true);
       UIManager.Instance.characterInfo = characterInfo;
       UIManager.Instance.DisplayDialogue(characterInfo.dialogueList[currentDialogueIdx]);
   }
   
   //gére le comportement du bouton continue, est a appeler au onclick du bouton continuer
   public void ContinueButton()
   {
       switch (characterInfo.dialogueList[currentDialogueIdx].type)
       {
           case DialogueLine.DialogueType.Dialogue:
               currentDialogueIdx = characterInfo.dialogueList[currentDialogueIdx].nextLineIndex;
               UIManager.Instance.DisplayDialogue(characterInfo.dialogueList[currentDialogueIdx]);
               break;
           case DialogueLine.DialogueType.BadEnd:
               UIManager.Instance.gameObject.SetActive(false);
               Player.instance.canMove = true;
               Player.instance.canInteract = true;
               break;
           case DialogueLine.DialogueType.GoodEnd:
               UIManager.Instance.gameObject.SetActive(false);
               Player.instance.canMove = true;
               Player.instance.canInteract = true;
               break;
           default:
               break;
       }
   }
   
   public void Choicemaker(int choiceParam)
   {
       currentDialogueIdx = choiceParam;
       UIManager.Instance.DisplayDialogue(characterInfo.dialogueList[currentDialogueIdx]);
   }
}
