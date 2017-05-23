using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    string verticalAxisName;
    [SerializeField]
    string horizontalAxisName;

    float verticalInput;
    float horizontalInput;

    void Update()
    {
        verticalInput = Input.GetAxis(verticalAxisName);
        horizontalInput = Input.GetAxis(horizontalAxisName);
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
