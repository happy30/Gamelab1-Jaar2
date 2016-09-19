//InteractScript by Jordi

using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour
{
    public bool isTriggered;
	

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //ui.showinteracttext;
            if(Input.GetButtonDown("Slash"))
            {
                isTriggered = true;
            }
        }
    }
}
