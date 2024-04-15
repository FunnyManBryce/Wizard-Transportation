using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> possibleCharacters;
    public List<GameObject> characters;
    public int charPerDay;
    public GameObject currentCharacter;
    public GameObject gamePanel;
    public GameObject outlibe;
    public GameObject nightPanel;
    public CharVariables currentVariables;
    public int popularity = 70;
    public int gold = 100;


    public PopBar PopularityBar;
    public TimeManager timeManager;

    private void Start()
    {
        PopularityBar.SetPopularity(popularity);
        for(int i = 1; i <= charPerDay; i++)
        {
            Debug.Log("balls");
            currentCharacter = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
            characters.Add(currentCharacter);
            possibleCharacters.Remove(currentCharacter);
            currentCharacter.transform.position = new Vector3(-6.5f, -1.5f, 0);
        }
        currentCharacter = characters[0];
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
            popularity = popularity + currentVariables.reputationReward;
            PopularityBar.SetPopularity(popularity);
        }
        else
        {
            popularity = popularity - currentVariables.reputationReward;
            PopularityBar.SetPopularity(popularity);
        }
        characters.Remove(currentCharacter);
        Destroy(currentCharacter);
        currentCharacter = characters[0];
        currentCharacter.gameObject.SetActive(true);

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
            popularity = popularity - currentVariables.reputationReward;
            PopularityBar.SetPopularity(popularity);
        }
        characters.Remove(currentCharacter);
        Destroy(currentCharacter);
        currentCharacter = characters[0];
        currentCharacter.gameObject.SetActive(true);

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
        outlibe.SetActive(true);
        gamePanel.SetActive(true);
        nightPanel.SetActive(false);
        timeManager.timeScale = 10f;
    }
}
