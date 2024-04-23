using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameManager gameManager;
    public string dialogueToPlay = "Now this is epic";
    public TMP_Text Dialogue;
    //public float timePerCharacter = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("CharacterDialogue");
    }

    // Update is called once per frame
    void Update()
    {
        //dialogueToPlay = gameManager.currentCharacter.GetComponent<CharacterDisplay>().display.initalDialogue;
    }

    public IEnumerator CharacterDialogue()
    {
        Dialogue.text = "";
        for (int i = 0; i < dialogueToPlay.Length; i++)
        {
            Dialogue.text = Dialogue.text + dialogueToPlay[i];
            yield return new WaitForSeconds(0.075f);
        }
    }
}
