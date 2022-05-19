using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Antialiasing : MonoBehaviour
{

    void Start()
    {
        Unity.XR.Oculus.Utils.SetFoveationLevel(4);
    }

    public void Resolution_100()
    {
        XRSettings.eyeTextureResolutionScale = 1.00f;
    }

    public void Resolution_125()
    {
        XRSettings.eyeTextureResolutionScale = 1.25f;
    }

    public void Resolution_150()
    {
        XRSettings.eyeTextureResolutionScale = 1.50f;
    }

    public void Resolution_200()
    {
        XRSettings.eyeTextureResolutionScale = 2.00f;
    }

    public void Foveated_Low()
    {
        Unity.XR.Oculus.Utils.SetFoveationLevel(1);
    }

    public void Foveated_Medium()
    {
        Unity.XR.Oculus.Utils.SetFoveationLevel(2);
    }

    public void Foveated_High()
    {
        Unity.XR.Oculus.Utils.SetFoveationLevel(3);
    }

    public void Foveated_HighTop()
    {
        Unity.XR.Oculus.Utils.SetFoveationLevel(4);
    }

    public void MSAA_OFF()
    {
        QualitySettings.antiAliasing = 0;
    }

    public void MSAA_X2()
    {
        QualitySettings.antiAliasing = 2;
    }

    public void MSAA_X4()
    {
        QualitySettings.antiAliasing = 4;
    }

    public void Quality_MSAA_OFF()
    {
        QualitySettings.SetQualityLevel(0, true);
        Unity.XR.Oculus.Utils.SetFoveationLevel(4);

    }

    public void Quality_MSAA_X2()
    {
        QualitySettings.SetQualityLevel(1, true);
        Unity.XR.Oculus.Utils.SetFoveationLevel(4);

    }

    public void Quality_MSAA_X4()
    {
        QualitySettings.SetQualityLevel(2, true);
        Unity.XR.Oculus.Utils.SetFoveationLevel(4);

    }

    public void Quality_MSAA_X8()
    {
        QualitySettings.SetQualityLevel(4, true);
        Unity.XR.Oculus.Utils.SetFoveationLevel(4);

    }


    public void RefreshRate_90()
    {
        //OVRManager.display.displayFrequency = 90.0f;
        //OVRPlugin.systemDisplayFrequency = 90.0f;
        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(90);
    }
    public void RefreshRate_72()
    {
        //OVRManager.display.displayFrequency = 72.0f;
        //OVRPlugin.systemDisplayFrequency = 72.0f;
        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(72);
    }
    public void RefreshRate_60()
    {
        //OVRManager.display.displayFrequency = 60.0f;
        //OVRPlugin.systemDisplayFrequency = 60.0f;
        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(60);
    }


    /*
    public void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            Menu.active = !Menu.active;
        }
    }
    */
}


