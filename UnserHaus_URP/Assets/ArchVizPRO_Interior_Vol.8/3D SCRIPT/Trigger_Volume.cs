using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Volume : MonoBehaviour
{
    public GameObject Ceiling_Props_Livingroom;
    public GameObject Ceiling_Props_Bedroom;
    public GameObject Ceiling_Props_Guestroom;
    public GameObject Ceiling_Props_Bathroom_Main;
    public GameObject Ceiling_Props_Bathroom_Bedroom;

    public Camera MainCamera;

    private void Start()
    {
        MainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            //other.attachedRigidbody.AddForce(Vector3.up * 10);
            Ceiling_Props_Livingroom.SetActive(true);
            Ceiling_Props_Bedroom.SetActive(true);
            Ceiling_Props_Guestroom.SetActive(true);
            Ceiling_Props_Bathroom_Main.SetActive(true);
            Ceiling_Props_Bathroom_Bedroom.SetActive(true);

            Debug.Log("I am inside");

            MainCamera.clearFlags = CameraClearFlags.Skybox;
        }
    }

    private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody)
            {
            Ceiling_Props_Livingroom.SetActive(false);
            Ceiling_Props_Bedroom.SetActive(false);
            Ceiling_Props_Guestroom.SetActive(false);
            Ceiling_Props_Bathroom_Main.SetActive(false);
            Ceiling_Props_Bathroom_Bedroom.SetActive(false);

            Debug.Log("I am otside");

            MainCamera.clearFlags = CameraClearFlags.SolidColor;
        }
    }

    public void Show_Ceiling_Props()
    {
        Ceiling_Props_Livingroom.SetActive(true);
        Ceiling_Props_Bedroom.SetActive(true);
        Ceiling_Props_Guestroom.SetActive(true);
        Ceiling_Props_Bathroom_Main.SetActive(true);
        Ceiling_Props_Bathroom_Bedroom.SetActive(true);
    }

    public void Hide_Ceiling_Props()
    {
        Ceiling_Props_Livingroom.SetActive(false);
        Ceiling_Props_Bedroom.SetActive(false);
        Ceiling_Props_Guestroom.SetActive(false);
        Ceiling_Props_Bathroom_Main.SetActive(false);
        Ceiling_Props_Bathroom_Bedroom.SetActive(false);
    }
}
