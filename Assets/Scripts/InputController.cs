using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField]
    string verticalAxisName;
    [SerializeField]
    string horizontalAxisName;
    [SerializeField]
    string fireButtonName;

    float verticalInput;
    float horizontalInput;

    public UnityAction onFirePressed;

    void Update()
    {
        verticalInput = Input.GetAxis(verticalAxisName);
        horizontalInput = Input.GetAxis(horizontalAxisName);

        if (Input.GetButton(fireButtonName) && onFirePressed != null)
        {
            onFirePressed();
        }
    }

    public float VerticalInput
    {
        get
        {
            return verticalInput;
        }
    }

    public float HorizontalInput
    {
        get
        {
            return horizontalInput;
        }
    }

}
