using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool UserAttivo = false;

    public void Update()
    {
        if (Input.GetKeyUp("5"))
        {
            UserAttivo = !UserAttivo;
        }
    }
}
