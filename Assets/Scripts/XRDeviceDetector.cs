using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum XRDeviceType
{
    PICO_G2_4k,
    PICO_NEO3,
    UNDEFINED
};

public class XRDeviceDetector : MonoBehaviour
{
    private static bool isInit = false;
    private static XRDeviceType type = XRDeviceType.UNDEFINED;

    private void Awake() 
    {
        if (!isInit)
        {
            isInit = true;

            //Debug.Log("Device model: " + SystemInfo.deviceModel);

            switch(SystemInfo.deviceModel)
            {
                case "Pico Pico G2 4K": type = XRDeviceType.PICO_G2_4k; break;
                case "Pico Pico Neo 3": type = XRDeviceType.PICO_NEO3;  break;
                default:                type = XRDeviceType.UNDEFINED;  break;
            }

        }
    }

    public static XRDeviceType GetType()
    {
        return type;
    }
}
