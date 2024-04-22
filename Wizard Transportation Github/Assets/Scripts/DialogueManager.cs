using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dialogue.text = gameManager.currentCharacter.GetComponent<CharacterDisplay>().display.initalDialogue;
    }
}
