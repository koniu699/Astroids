using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapController : MonoBehaviour
{
    [SerializeField]
    Transform objectToWrap;

    Vector2 topLeftCorner;
    Vector2 bottomRightCorner;

    List<Renderer> renderers = new List<Renderer>();

    Camera mainCam;

    bool xWrap = false;
    bool yWrap = false;

    void Awake()
    {
        renderers.AddRange(objectToWrap.GetComponentsInChildren<Renderer>());
        mainCam = Camera.main;
    }

    void Update()
    {
        bool visible = IsVisible((renderers));

        if (visible)
        {
            xWrap = false;
            yWrap = false;
            return;
        }
        else if (xWrap && yWrap)
            return;
        else
        {
            Vector2 viewportPoint = mainCam.WorldToViewportPoint(objectToWrap.transform.position);

            if ((viewportPoint.x < 0 || viewportPoint.x > 1) && !xWrap)
            {
                objectToWrap.position = new Vector2(-objectToWrap.position.x, objectToWrap.position.y);
                xWrap = true;
            }
            if ((viewportPoint.y < 0 || viewportPoint.y > 1) && !yWrap)
            {
                objectToWrap.position = new Vector2(objectToWrap.position.x, -objectToWrap.position.y);
                yWrap = true;
            }
        }
    }

    bool IsVisible(List<Renderer> renderersToCheck)
    {
        foreach (var rendererToCheck in renderersToCheck)
        {
            if (rendererToCheck.isVisible)
                return true;
        }
        return false;
    }
}
