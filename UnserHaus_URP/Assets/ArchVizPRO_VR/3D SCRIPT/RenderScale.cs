

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderScale : MonoBehaviour
{

    public float Scale = 1.2f;

    void Start()
    {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = Scale;
    }

}
