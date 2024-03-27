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
    public float age;
    public string characterClass;
    public bool isAllowed;
    public bool isRobot;
    public string destination;

    //Bag
    public bool hasBag;
    public GameObject[] belongings;

    //ID Stats
    public bool hasID;
    public string IDName;
    public string IDSpecies;
    public string IDAge;
    public string IDClass;

    //TicketStats
    public bool hasTicket;
    public string ticketExpirationDate;
    public string ticketName;
    public string ticketDestination;

    //Accepting/Denying Stats
    public int goldReward;
    public int reputationReward;
    public bool isBribing;
    public int bribeAmount;
    public string denialReason;

    
    
}
