using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatsController : MonoBehaviour
{
    [SerializeField]
    ShipConfig shipConfig;

    int points;

    private void Awake()
    {
        GlobalGameController.Instance.RegisterPlayer(gameObject);
    }

    public ShipConfig ShipConfig
    {
        get { return shipConfig; }
    }

    public int Points
    {
        get { return points; }
    }

    public int AwardPoints(int amount)
    {
        points += amount;
        return points;
    }
}
