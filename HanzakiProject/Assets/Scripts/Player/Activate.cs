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
            
        }
        else
        {
            
        }
    }

    public void FocusCamera()
    {
        Camera.main.gameObject.GetComponent<CameraController>().followObject = gameObject;
        Camera.main.gameObject.GetComponent<CameraController>().inCutscene = true;
        activated = true;
    }

    public void DefocusCamera()
    {
        Camera.main.gameObject.GetComponent<CameraController>().inCutscene = false;
        activated = false;
    }
}

