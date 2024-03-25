using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int popularity = 5;

    public PopBar PopularityBar;

    private void Start()
    {
        PopularityBar.SetPopularity(popularity);
    }
}
