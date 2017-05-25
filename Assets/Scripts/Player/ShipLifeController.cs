using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipLifeController : MonoBehaviour
{
    [SerializeField]
    string enemyTag;
    [SerializeField]
    ShipStatsController statsController;

    int maxLife;
    int currentLife;

    public UnityAction onDeathAction;
    public UnityAction onRespawnAction;

    private void Awake()
    {
        InitShip();
    }

    public void InitShip()
    {
        maxLife = statsController.ShipConfig.ShipLife;
        currentLife = maxLife;
    }

    public bool IsAlive()
    {
        return currentLife >= maxLife;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            currentLife--;

            if (!IsAlive() && onDeathAction != null)
            {
                onDeathAction();
                gameObject.SetActive(false);
            }
        }
    }

    public void RespawnPlayer()
    {
        InitShip();
        if (onRespawnAction != null)
            onRespawnAction();
    }
}
