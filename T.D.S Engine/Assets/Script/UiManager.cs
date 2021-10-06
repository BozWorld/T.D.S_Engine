using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  public Image background;
  public Image characterImage;
  public Image dialogueBox;
  public TextMeshProUGUI dialogueBoxText;
  public GameObject canvas;
  public TextMeshProUGUI nameZoneText;
  public Button continueButton;
  public Transform buttonList;
  public List<ChoiceButton> choiceButton;
  public Image descriptionImage;
  public TextTyper textTyper;
  public static UIManager Instance;
  private CharacterInfo _characterInfo;
  [SerializeField] [Range(0, 1)] public float typingSpeed;
  public DialogueHandler dialogueHandler;
  
  //c'est une expression lambda c'est un principe un poil complexe qui mérite d'etre dig
  public delegate void OnTextDisplayEnd();

  public OnTextDisplayEnd onTextDisplayEnd;
  

  void Awake ()
  {
    if (Instance == null)
      Instance = this;
    else
      Destroy (gameObject);
  }
  
  //cet fonction gère uniquement l'affichage du dialogue
  public void DisplayDialogue(DialogueLine dialogueLine)
  {
    int spriteidx = dialogueLine.characterSpriteIdx;
    characterImage.sprite = _characterInfo.CharacterSprite[spriteidx];
    DisplayContinueButton(false);
    textTyper.StartTyping(dialogueLine,dialogueBoxText,typingSpeed);
    if (dialogueLine.type == DialogueLine.DialogueType.Choice)
    {
      onTextDisplayEnd = DisplayChoice;
    }
    else
    {
      onTextDisplayEnd = () => DisplayContinueButton(true);
      //lambda expression
    }
    
    
  }
  
  //displaychoice sert principalement a géré l'affichage des boutons choix et leurs assignations vers ou te renvoyé
  public void DisplayChoice()
  { 
    DisplayContinueButton(false);
    int count = characterInfo.dialogueList[dialogueHandler.currentDialogueIdx].choices.Count;
    for (int i = 0; i < count; i++)
    {
      choiceButton[i].gameObject.SetActive(true);
      Choice c = characterInfo.dialogueList[dialogueHandler.currentDialogueIdx].choices[i]; 
      choiceButton[i].InitChoiceButton(c);
    }
  }
  
  //gére l'évènement qui s'enclenche quand on a sélectionné un choix
  public void OnClickChoiceButton(int nextLine)
  {
    foreach ( ChoiceButton button in choiceButton)
    {
      button.gameObject.SetActive(false);
    }
    dialogueHandler.Choicemaker(nextLine);
  }
  
  //c'est une fonction gérant l'affichage du bouton continuer, il récupére un type bool pour que depuis l'ondroit ou on l'appel il s'affiche ou non
  public void DisplayContinueButton(bool canContinue)
  {
    continueButton.gameObject.SetActive(canContinue);
  }
  
  //getter et setter du character info cet élèments est ce qui est censée etre donné a l'UImanager/handler pour savoir qui parle et les info de qui parle
  public CharacterInfo characterInfo
  {
    get => _characterInfo;
    set
    {
      _characterInfo = value;
      characterImage.sprite = _characterInfo.CharacterSprite[0];
      nameZoneText.text = _characterInfo.CharacterName;
    }
  }
}
