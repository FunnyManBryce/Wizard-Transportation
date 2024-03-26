using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
