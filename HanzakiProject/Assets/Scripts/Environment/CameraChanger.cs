using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour
{
    public GameObject cameraPos;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(Camera.main.gameObject.GetComponent<CameraController>().inPuzzle)
            {
                Camera.main.gameObject.GetComponent<CameraController>().inPuzzle = false;
            }
            else
            {
                Camera.main.gameObject.GetComponent<CameraController>().followObject = cameraPos;
                Camera.main.gameObject.GetComponent<CameraController>().inPuzzle = true;
            }
        }
    }


}
