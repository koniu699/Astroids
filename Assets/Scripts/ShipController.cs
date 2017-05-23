using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D shipRigidbody;

    [SerializeField]
    ShipConfig shipConfig;
    [SerializeField]
    InputController inputController;

    private void FixedUpdate()
    {
        float torque = 0;
        if (!Mathf.Approximately(inputController.HorizontalInput, 0))
        {
            torque = (inputController.HorizontalInput > 0) ? -shipConfig.ShipRotationSpeed : shipConfig.ShipRotationSpeed;
            shipRigidbody.AddTorque(torque);
        }

        if (inputController.VerticalInput > 0 && shipRigidbody.velocity.SqrMagnitude() < shipConfig.ShipMaxLinearVelocity)
        {
            shipRigidbody.AddRelativeForce(new Vector2(0, shipConfig.ShipSpeed));
        }
    }


}
