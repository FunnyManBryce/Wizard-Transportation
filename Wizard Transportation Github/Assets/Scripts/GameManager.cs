using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> characters;
    public GameObject currentCharacter;
    public CharVariables currentVariables;
    public int charactersLeft;
    public int popularity = 70;
    public int gold = 100;


    public PopBar PopularityBar;

    private void Start()
    {
        PopularityBar.SetPopularity(popularity);
    }
    private void Update()
    {
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
    }
}
