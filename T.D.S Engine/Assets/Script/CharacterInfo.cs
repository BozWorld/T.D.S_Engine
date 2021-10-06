using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private List<Sprite> myCharacterSprites = null;

    public List<Sprite> CharacterSprite
    {
        get { return myCharacterSprites; }
        private set { myCharacterSprites = value; }
    }

    [SerializeField] private string myCharacterName;
    
    public string CharacterName
    {
        get { return myCharacterName; }
        private set { myCharacterName = value; }
    }
    [SerializeField] private Sprite myDescriptionSprite;

    public Sprite DescriptionSprite
    {
        get { return myDescriptionSprite; }
        private set { myDescriptionSprite = value; }
    }
    [SerializeField] private List<DialogueLine> myDialogueList  = new List<DialogueLine>();
    
    public List<DialogueLine> dialogueList
    {
        get { return myDialogueList; }
        private set { myDialogueList = value; }
    }
}
