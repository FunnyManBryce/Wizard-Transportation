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
    
}
