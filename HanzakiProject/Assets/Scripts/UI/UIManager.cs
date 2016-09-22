using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject letterboxes;
    public GameObject topLetterbox;
    public GameObject bottomLetterbox;
    public GameObject chatPanel;

    public Text npcNameText;
    public Text cutsceneText;
    public Text interactText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnterCutscene()
    {
        topLetterbox.GetComponent<Animator>().SetBool("SlideIn", true);
        bottomLetterbox.GetComponent<Animator>().SetBool("SlideIn", true);
    }

    public void ExitCutscene()
    {
        topLetterbox.GetComponent<Animator>().SetBool("SlideIn", false);
        bottomLetterbox.GetComponent<Animator>().SetBool("SlideIn", false);
    }

    //Set the text in the chatpanel
    public void UpdateText(string name, string text)
    {
        npcNameText.text = name;
        cutsceneText.text = text;
    }

    public void ChangeInteractText(InteractScript interactObject)
    {
        if(!Camera.main.GetComponent<CameraController>().inCutscene)
        {
            interactText.text = "Press Z to " + interactObject.interactText;
        }
        else
        {
            interactText.text = "";
        }
    }

    public void RemoveInteractText()
    {
        interactText.text = "";
    }
}
