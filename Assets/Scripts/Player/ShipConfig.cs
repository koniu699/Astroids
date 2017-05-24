using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipConfig.asset", menuName = "Asteroid/New Ship Config")]
public class ShipConfig : ScriptableObject
{
    [SerializeField]
    float shipSpeed;
    [SerializeField]
    float shipRotationSpeed;
    [SerializeField]
    float shipMaxLinearVelocity;
    [SerializeField]
    int shipLife;

    public float ShipSpeed
    {
        get
        {
            return shipSpeed;
        }
    }

    public float ShipRotationSpeed
    {
        get
        {
            return shipRotationSpeed;
        }
    }
    public float ShipMaxLinearVelocity
    {
        get
        {
            return shipMaxLinearVelocity * shipMaxLinearVelocity;
        }
    }
    public int ShipLife
    {
        get
        {
            return shipLife;
        }
    }
}
