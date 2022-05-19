using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
//using Valve.VR.InteractionSystem;
using TMPro;



public class FadeUI_v7 : MonoBehaviour
{
    Renderer Manager_Renderer;

    public float Alpha = 0;
    public CanvasGroup CanvasGroupUI;
    public Transform Billboard;

    ///  DISTANCE ////////

    float Distance_Value;
    public float Distance_Range;
    public float Distance_Range_Near = 0.5f;
    Transform MainCamera;

    // DELAY //

    public float DelaySpeed;
    public float FadeSpeed;

    /// COROUTINE ///

    public TMP_Text textCompTitle;
    public TMP_Text textCompInfo;
    public TMP_Text textCompMaterial;
    public TMP_Text textCompDescription;

    public bool IsVisible = false;
    public bool InDistance = false;
    public bool IsActive = false;
    public bool IsON = true;
    public bool isCoroutineDelayStarted = false;

    public Manager ManagerScript;
   // public Teleport TeleportScript;
    public bool IsBillboard = false;

    void Start()
    {
        Manager_Renderer = GetComponent<Renderer>();
        MainCamera = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        // ATTIVO O DISATTIVO DA USER //

        if (ManagerScript.UserAttivo)
        {
            IsON = true;
        } else
        {
            IsON = false;
        }
        // VISIBLE //

        if (Manager_Renderer.isVisible)
        {
            IsVisible = true;
        }
        else if (!Manager_Renderer.isVisible)
        {
            IsVisible = false;
            IsActive = false;
        }

        // DISTANCE //

        Distance_Value = Vector3.Distance(transform.position, MainCamera.transform.position);

        if (Distance_Value < Distance_Range && Distance_Value > Distance_Range_Near)
        {
            InDistance = true;
        } else
        {
            InDistance = false;
        }

        // ALPHA //

        if (IsVisible && InDistance && IsON && !IsActive)
        {
            if (!isCoroutineDelayStarted)
            {
                StartDelay();
            }
        }
        if (IsVisible && InDistance && IsActive && IsON)
        {
            Alpha += FadeSpeed * Time.deltaTime;
            //////////////////////////////StartAutotype();
        }
        if (!IsVisible && !InDistance)
        {
            Alpha -= 2 * FadeSpeed * Time.deltaTime;
        }
        if (!IsVisible && InDistance)
        {
            Alpha -= 2 * FadeSpeed * Time.deltaTime;
        }
        if (IsVisible && !InDistance)
        {
            Alpha -= 2 * FadeSpeed * Time.deltaTime;
        }
        if (!IsON)
        {
            Alpha -= 2 * FadeSpeed * Time.deltaTime;
        }


        CanvasGroupUI.alpha = Alpha;

        if (Alpha > 1)
        {
            Alpha = 1;
        }
        if (Alpha < 0)
        {
            Alpha = 0;
            //////////////////////////////ResetAutotype();
            textCompTitle.enabled = false;
            textCompInfo.enabled = false;
            textCompMaterial.enabled = false;
            textCompDescription.enabled = false;

            IsActive = false;
        }
        if (Alpha > 0)
        {
            textCompTitle.enabled = true;
            textCompInfo.enabled = true;
            textCompMaterial.enabled = true;
            textCompDescription.enabled = true;
        }

        // BILLBOARD //
        if (Billboard && IsBillboard)
        {
            Vector3 targetPostition = new Vector3(MainCamera.position.x, this.transform.position.y, MainCamera.position.z);
            Billboard.transform.LookAt(targetPostition);
            Billboard.transform.Rotate(0, 180, 0);
        }
        /*
        if (TeleportScript.teleporting == true)
        {
            IsBillboard = true;
        }
        else
        {
            IsBillboard = false;
        }
        */
        // DISABLE RAYCAST//
        if (Alpha > 0.1)
        {
            CanvasGroupUI.blocksRaycasts = true;
        }
        else
        {
            CanvasGroupUI.blocksRaycasts = false;
        }
    }


    



    // DELAY //

    void StartDelay()
    {
        if (!isCoroutineDelayStarted)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {

        isCoroutineDelayStarted = true;
        yield return new WaitForSeconds(DelaySpeed);
        isCoroutineDelayStarted = false;
        IsActive = true;
    }
}
