//Activate by Jordi

using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour
{
    public bool activated;

    void Update()
    {
        if(activated)
        {
            Camera.main.gameObject.GetComponent<CameraController>().followObject = gameObject;
            Camera.main.gameObject.GetComponent<CameraController>().inCutscene = true;
        }
        else
        {
            Camera.main.gameObject.GetComponent<CameraController>().inCutscene = false;
        }
    }
}

