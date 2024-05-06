using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameManager gameManager;
    public string dialogueToPlay = "Now this is epic";
    public TMP_Text Dialogue;
    public bool finished = false;
    //public float timePerCharacter = 10f;
    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator CharacterDialogue()
    {
        Dialogue.text = "";
        for (int i = 0; i < dialogueToPlay.Length; i++)
        {
            Dialogue.text = Dialogue.text + dialogueToPlay[i];
            if( i > dialogueToPlay.Length - 2)
            {
                finished = true;
            }
            yield return new WaitForSeconds(0.075f);
            
        }
    }
}
