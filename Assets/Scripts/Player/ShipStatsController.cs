using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatsController : MonoBehaviour
{
    [SerializeField]
    ShipConfig shipConfig;

    public ShipConfig ShipConfig
    {
        get { return shipConfig; }
    }
}
