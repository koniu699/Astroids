using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer engineRenderer;
    [SerializeField]
    AudioSource engineAudioSource;
    [SerializeField]
    InputController inputController;
    [SerializeField]
    ShipLifeController lifeController;

    private void Awake()
    {
        lifeController.onDeathAction += OnDeathAction;
        lifeController.onRespawnAction += OnRespawnAction;
    }

    private void Update()
    {
        if (!lifeController.IsAlive())
            return;

        if (engineRenderer.enabled && Mathf.Approximately(inputController.VerticalInput, 0f))
        {
            ChangeEngineStatus(false);
        }
        else if (!engineRenderer.enabled && inputController.VerticalInput > 0)
        {
            ChangeEngineStatus(true);
        }
    }

    private void OnDestroy()
    {
        lifeController.onDeathAction -= OnDeathAction;
        lifeController.onRespawnAction -= OnRespawnAction;
    }

    void OnDeathAction()
    {
        ChangeEngineStatus(false);
    }

    void OnRespawnAction()
    {
        ChangeEngineStatus(true);
    }

    void ChangeEngineStatus(bool status)
    {
        engineRenderer.enabled = status;
        engineAudioSource.enabled = status;
    }

}
