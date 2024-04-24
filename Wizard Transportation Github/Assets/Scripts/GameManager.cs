using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public List<GameObject> possibleCharacters;
    public List<GameObject> characters;
    public int charPerDay;
    public GameObject currentCharacter;
    public DialogueManager dialogueManager;
    public GameObject gamePanel;
    public GameObject outlibe;
    public GameObject nightPanel;
    public GameObject loseScreen;
    public CharVariables currentVariables;
    public int popularity = 70;
    public int gold = 100;
    public int Day = 1;
    public float deskXStart, deskXEnd;
    public float deskYStart, deskYEnd;

    public TMP_Text goldDisplay;
    public TMP_Text dayDisplay;
    public PopBar PopularityBar;
    public TimeManager timeManager;

    private void Start()
    {
        goldDisplay.text = "Gold: " + gold;
        dayDisplay.text = "Day: " + Day;
        PopularityBar.SetPopularity(popularity);
        for(int i = 1; i <= charPerDay; i++)
        {
            currentCharacter = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
            characters.Add(currentCharacter);
            //possibleCharacters.Remove(currentCharacter);
            //currentCharacter.transform.position = new Vector3(-6.5f, -1.5f, 0);
        }
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        dialogueManager.dialogueToPlay = currentCharacter.GetComponent<CharacterDisplay>().display.initalDialogue;
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
    }
    private void Update()
    {
        if(characters.Count == 0)
        {
            EndDay();
        }
        if (popularity > 100)
        {
            popularity = 100;
            PopularityBar.SetPopularity(popularity);
        }
    }
    public void Accept()
    {
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if(currentVariables.isAllowed == true)
        {
            gold = gold + currentVariables.goldReward;
            goldDisplay.text = "Gold: " + gold;
            popularity = popularity + currentVariables.reputationReward;
            PopularityBar.SetPopularity(popularity);
        }
        else
        {
            popularity = popularity - currentVariables.reputationPenalty;
            PopularityBar.SetPopularity(popularity);
        }
        characters.Remove(currentCharacter);
        //Destroy(currentCharacter);
        //currentCharacter.transform.position = new Vector3(-30, -1.5f, 0);
        currentCharacter.SetActive(false);
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        dialogueManager.dialogueToPlay = currentCharacter.GetComponent<CharacterDisplay>().display.initalDialogue;
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
        if (popularity < 0)
        {
            Lose();
        }
    }
    public void Deny()
    {
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if (currentVariables.isAllowed == false)
        {
            popularity = popularity + currentVariables.reputationReward;
            PopularityBar.SetPopularity(popularity);
        }
        else
        {
            popularity = popularity - currentVariables.reputationPenalty;
            PopularityBar.SetPopularity(popularity);
        }
        characters.Remove(currentCharacter);
        //Destroy(currentCharacter);
        //currentCharacter.transform.position = new Vector3(-30, -1.5f, 0);
        currentCharacter.SetActive(false);
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        dialogueManager.dialogueToPlay = currentCharacter.GetComponent<CharacterDisplay>().display.initalDialogue;
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
        if (popularity < 0)
        {
            Lose();
        }
    }
    public void EndDay()
    {
        outlibe.SetActive(false);
        gamePanel.SetActive(false);
        nightPanel.SetActive(true);
        timeManager.timeScale = 0f;
    }
    public void StartDay()
    {
        Day++;
        dayDisplay.text = "Day: " + Day;
        outlibe.SetActive(true);
        gamePanel.SetActive(true);
        nightPanel.SetActive(false);
        timeManager.timeScale = 10f;
        for (int i = 1; i <= charPerDay; i++)
        {
            currentCharacter = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
            characters.Add(currentCharacter);
            //possibleCharacters.Remove(currentCharacter);
            //currentCharacter.transform.position = new Vector3(-6.5f, -1.5f, 0);
        }
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        dialogueManager.dialogueToPlay = currentCharacter.GetComponent<CharacterDisplay>().display.initalDialogue;
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
    }
    public void OpenBelongings()
    {
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;

        foreach (GameObject belongings in currentVariables.belongings) 
        {            
            RectTransform panelRectTransform = gamePanel.GetComponent<RectTransform>();

            float xPos = Random.Range(Mathf.Max(panelRectTransform.rect.xMin, deskXStart), Mathf.Min(panelRectTransform.rect.xMax, deskXEnd));
            float yPos = Random.Range(Mathf.Max(panelRectTransform.rect.yMin, deskYStart), Mathf.Min(panelRectTransform.rect.yMax, deskYEnd));

            Vector3 worldPosition = panelRectTransform.TransformPoint(new Vector3(xPos, yPos, 0));

            Instantiate(belongings, worldPosition, Quaternion.identity, gamePanel.transform);
        }
    }
    public void Lose()
    {
        loseScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("BryceScene");
        loseScreen.SetActive(false);
    }
}
