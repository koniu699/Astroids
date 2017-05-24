using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D shipRigidbody;

    [SerializeField]
    ShipStatsController statsController;
    [SerializeField]
    InputController inputController;
    [SerializeField]
    ShipLifeController lifeController;

    private void FixedUpdate()
    {
        if (!lifeController.IsAlive())
            return;

        float torque = 0;
        if (!Mathf.Approximately(inputController.HorizontalInput, 0))
        {
            torque = (inputController.HorizontalInput > 0) ? -statsController.ShipConfig.ShipRotationSpeed : statsController.ShipConfig.ShipRotationSpeed;
            shipRigidbody.AddTorque(torque);
        }

        if (inputController.VerticalInput > 0 && shipRigidbody.velocity.SqrMagnitude() < statsController.ShipConfig.ShipMaxLinearVelocity)
        {
            shipRigidbody.AddRelativeForce(new Vector2(0, statsController.ShipConfig.ShipSpeed));
        }
    }


}
