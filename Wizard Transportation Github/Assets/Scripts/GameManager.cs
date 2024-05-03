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
    public int gold = 25;
    public int Day = 1;
    public float deskXStart, deskXEnd;
    public float deskYStart, deskYEnd;
    private bool isDragging = false;
    private Vector3 offset;

    public TMP_Text goldDisplay;
    public TMP_Text dayDisplay;
    public PopBar PopularityBar;
    public TimeManager timeManager;

    private void Start()
    {
        for (int i = 0; i <= possibleCharacters.Count - 1; i++) //REALLY important for generation system to reset
        {
            currentCharacter = possibleCharacters[i];
            currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
            currentVariables.genCount = 0;
            Debug.Log(i);
        }
        goldDisplay.text = "Gold: " + gold;
        dayDisplay.text = "Day: " + Day;
        PopularityBar.SetPopularity(popularity);
        for(int i = 1; i <= charPerDay; i++)
        {
            currentCharacter = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
            characters.Add(currentCharacter);
            possibleCharacters.Remove(currentCharacter);
            //currentCharacter.transform.position = new Vector3(-6.5f, -1.5f, 0);
        }
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if (currentVariables.Generation == true)
        {
            dialogueManager.dialogueToPlay = currentVariables.genDialogue[currentVariables.genCount];
        }
        else
        {
            dialogueManager.dialogueToPlay = currentVariables.initalDialogue;
        }
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
        DestroyBelongings();
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
            gold = gold - currentVariables.goldReward;
            goldDisplay.text = "Gold: " + gold;
            popularity = popularity - currentVariables.reputationPenalty;
            PopularityBar.SetPopularity(popularity);
        }
        possibleCharacters.Add(currentCharacter);
        characters.Remove(currentCharacter);
        //Destroy(currentCharacter);
        //currentCharacter.transform.position = new Vector3(-30, -1.5f, 0);
        currentCharacter.SetActive(false);
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if (currentVariables.Generation == true)
        {
            dialogueManager.dialogueToPlay = currentVariables.genDialogue[currentVariables.genCount];
        }
        else
        {
            dialogueManager.dialogueToPlay = currentVariables.initalDialogue;
        }
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
        if (popularity < 0 || gold < 0)
        {
            Lose();
        }
    }
    public void Deny()
    {
        DestroyBelongings();
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
        if (currentVariables.Generation == true && currentVariables.genCount < currentVariables.genImages.Count - 1)
        {
            Debug.Log("GENERATION");
            currentVariables.genCount++;
            //currentVariables.currentImage = currentVariables.genImages[0];
            //currentVariables.genImages.Remove(currentVariables.currentImage);
            currentVariables.currentImage = currentVariables.genImages[currentVariables.genCount];
            currentCharacter.GetComponent<SpriteRenderer>().sprite = currentVariables.currentImage;
        }
        possibleCharacters.Add(currentCharacter);
        characters.Remove(currentCharacter);
        //Destroy(currentCharacter);
        //currentCharacter.transform.position = new Vector3(-30, -1.5f, 0);
        currentCharacter.SetActive(false);
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if (currentVariables.Generation == true)
        {
            dialogueManager.dialogueToPlay = currentVariables.genDialogue[currentVariables.genCount];
        } else
        {
            dialogueManager.dialogueToPlay = currentVariables.initalDialogue;
        }
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
        if (popularity < 0 || gold < 0)
        {
            Lose();
        }
    }
    public void Kill()
    {
        DestroyBelongings();
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;

        if (currentVariables.isRobot == true && currentVariables.Generation == true && currentVariables.genCount < currentVariables.genImages.Count - 1) 
        {
            Debug.Log("GENERATION");
            currentVariables.genCount++;
            //currentVariables.currentImage = currentVariables.genImages[0];
            //currentVariables.genImages.Remove(currentVariables.currentImage);
            currentVariables.currentImage = currentVariables.genImages[currentVariables.genCount];
            currentCharacter.GetComponent<SpriteRenderer>().sprite = currentVariables.currentImage;
            popularity = popularity + (currentVariables.reputationReward * 2);
            gold = gold + 3;
            goldDisplay.text = "Gold: " + gold;
            PopularityBar.SetPopularity(popularity);
            possibleCharacters.Add(currentCharacter);
        }
        else if (currentVariables.isRobot == true)
        {
            popularity = popularity + (currentVariables.reputationReward * 3);
            gold = gold + 10;
            goldDisplay.text = "Gold: " + gold;
            PopularityBar.SetPopularity(popularity);
        }
        else if (currentVariables.isAllowed == false)
        {
            popularity = popularity - (currentVariables.reputationPenalty + 15);
            PopularityBar.SetPopularity(popularity);
        }
        else if (currentVariables.isAllowed == true)
        {
            popularity = popularity - (currentVariables.reputationPenalty + 30);
            PopularityBar.SetPopularity(popularity);
        }
        characters.Remove(currentCharacter);
        //Destroy(currentCharacter);
        currentCharacter.SetActive(false);
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if (currentVariables.Generation == true)
        {
            dialogueManager.dialogueToPlay = currentVariables.genDialogue[currentVariables.genCount];
        }
        else
        {
            dialogueManager.dialogueToPlay = currentVariables.initalDialogue;
        }
        dialogueManager.StopCoroutine("CharacterDialogue");
        dialogueManager.StartCoroutine("CharacterDialogue");
        if (popularity < 0 || gold < 0)
        {
            Lose();
        }
    }
    public void EndDay()
    {
        timeManager.currentTime = 600f;
        for (int i = 1; i <= characters.Count; i++)
        {
            currentCharacter = characters[0];
            possibleCharacters.Add(currentCharacter);
            characters.Remove(currentCharacter);
            popularity = popularity - 20;
            gold = gold - 3;
            goldDisplay.text = "Gold: " + gold;
            PopularityBar.SetPopularity(popularity);
            if (popularity < 0 || gold < 0)
            {
                Lose();
            }
            i--;
        }
        outlibe.SetActive(false);
        gamePanel.SetActive(false);
        nightPanel.SetActive(true);
        timeManager.timeScale = 0f;
    }
    public void StartDay()
    {
        Day++;
        gold = gold - 5;
        goldDisplay.text = "Gold: " + gold;
        dayDisplay.text = "Day: " + Day;
        if (popularity < 0 || gold < 0)
        {
            Lose();
        }
        outlibe.SetActive(true);
        gamePanel.SetActive(true);
        nightPanel.SetActive(false);
        timeManager.currentTime = 600f;
        timeManager.timeScale = 10f;
        for (int i = 1; i <= charPerDay; i++)
        {
            currentCharacter = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
            characters.Add(currentCharacter);
            possibleCharacters.Remove(currentCharacter);
        }
        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
        currentVariables = currentCharacter.GetComponent<CharacterDisplay>().display;
        if (currentVariables.Generation == true)
        {
            dialogueManager.dialogueToPlay = currentVariables.genDialogue[currentVariables.genCount];
        }
        else
        {
            dialogueManager.dialogueToPlay = currentVariables.initalDialogue;
        }
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
    private void DestroyBelongings()
    {
        GameObject[] belongings = GameObject.FindGameObjectsWithTag("Belongings");

        foreach (GameObject belonging in belongings)
        {
            Destroy(belonging);
        }
    }
}
