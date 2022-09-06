using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class G2ControllerAdjuster : MonoBehaviour
{
    private XRController controller;
    private XRInteractorLineVisual linerenderer;

    private void Awake()
    {
        controller = GetComponent<XRController>();
        linerenderer = GetComponent<XRInteractorLineVisual>();
    }

    private void Update()
    {
        if (controller.inputDevice.isValid)
        {
            linerenderer.lineLength = 20;
            linerenderer.lineWidth = 0.0025f;
        }
        else
        {
            linerenderer.lineLength = 0;
            linerenderer.lineWidth = 0;
        }
    }

    public void EnableLine(bool enable)
    {
        if (enable)
        {
            linerenderer.enabled = true;
            linerenderer.lineLength = 20;
            linerenderer.lineWidth = 0.0025f;
        }
        else
        {
            linerenderer.enabled = false;
            linerenderer.lineLength = 0;
            linerenderer.lineWidth = 0;
        }
    }
}
