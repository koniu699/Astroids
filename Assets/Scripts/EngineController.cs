using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour
{
    [SerializeField]
    GameObject shipEngine;
    [SerializeField]
    SpriteRenderer engineRenderer;
    [SerializeField]
    AudioSource engineAudioSource;
    [SerializeField]
    InputController inputController;

    private void Update()
    {
        if (engineRenderer.enabled && Mathf.Approximately(inputController.VerticalInput, 0f))
        {
            engineRenderer.enabled = false;
            engineAudioSource.enabled = false;
        }
        else if (!engineRenderer.enabled && inputController.VerticalInput > 0)
        {
            engineRenderer.enabled = true;
            engineAudioSource.enabled = true;
        }

    }

}
