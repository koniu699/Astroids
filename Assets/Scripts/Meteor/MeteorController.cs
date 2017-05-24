using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float torque;
    [SerializeField]
    int maxLife;
    [SerializeField]
    Rigidbody2D meteorRigidbody;

	ObjectPool meteorPool;

    int currentLife;

    private void Start()
    {
        currentLife = maxLife;
        SetupRandomMovement();
    }

    void SetupRandomMovement()
    {
        meteorRigidbody.AddForce(new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)), ForceMode2D.Impulse);
        meteorRigidbody.AddTorque(Random.Range(-torque, torque), ForceMode2D.Impulse);
    }

    public void DealDamage(int damage)
    {
        currentLife -= damage;
        if (currentLife <0)
        {
            meteorPool.ReturnObjectToPool(gameObject);
        }
    }
}
