using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharVariables : ScriptableObject
{
    //Real stats
    public string name;
    public string species;
    public int magicLevel;
    public string adventurerRank;
    public string height;
    public float age;
    public string characterClass;
    public bool isAllowed;
    public bool isRobot;
    public string destination;

    //Bag
    public bool hasBag;
    public GameObject[] belongings;

    //Accepting/Denying Stats
    public int goldReward;
    public int reputationReward;
    public int reputationPenalty;
    public bool isBribing;
    public int bribeAmount;
    public string denialReason;

    //Dialogue
    public string initalDialogue;
    public List<string> genDialogue;
    public string belongingDialouge;
    public string clearDialogue;
    public string kickDialogue;
    public string killDialogue;

    //Generations
    public bool Generation;
    public int genCount = 0;
    public Sprite currentImage;
    public List<Sprite> genImages;
}
