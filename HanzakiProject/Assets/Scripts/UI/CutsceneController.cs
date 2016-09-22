﻿using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public enum CutsceneType
    {
        MainQuest,
        SideQuest,
        OneTimeCutscene
    };

    CutsceneType cutsceneType;

    public QuestManager questManager;
    public UIManager ui;
    InteractScript _interact;


    public string npcName;
    public string[] CutsceneText;
    public string[] secondCutsceneText;

    //technical stuff
    public string[] fullLines;
    string fullDialogueLine;
    public string displayLine;
    public bool activated;

    int currentText;
    int currentChar;

    float scrollSpeed;

    void Awake()
    {
        _interact = GetComponent<InteractScript>();
        questManager = GameObject.Find("GameManager").GetComponent<QuestManager>();
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Start()
    {
        scrollSpeed = 0.05f;
    }
    

    void Update()
    {
        if(activated)
        {
            if (displayLine != fullDialogueLine)
            {
                if (!IsInvoking("NextChar"))
                {
                    Invoke("NextChar", scrollSpeed);
                }
            }
            //Each character will appear on screen one by one, if we click we speed up that process. If all characters are on-screen go to next line
            if (Input.GetKey(InputManager.Slash))
            {
                if (displayLine != fullDialogueLine)
                {
                    scrollSpeed = 0.05f;
                }
                else
                {
                    scrollSpeed = 0.05f;
                    SetNPCNameAndText();
                }
            }
            ui.UpdateText(npcName, displayLine);
        }
        
    }

    //Initialize the cutscene
    public void Activate()
    {
        StartCoroutine(DelayBeforeText());
    }

    //End the chat
    public void DeActivate()
    {
        currentText = 0;
        if(_interact.interactType == InteractScript.InteractType.OnTrigger)
        {
            Destroy(_interact.gameObject);
        }
        _interact.DeActivate();
        ui.chatPanel.SetActive(false);
        activated = false;
    }

    //Add a character one by one on screen
    public void NextChar()
    {
        if (currentChar < fullDialogueLine.Length)
        {
            displayLine += fullDialogueLine[currentChar];
            currentChar++;
        }
    }

    public void SetNPCNameAndText()
    {
        displayLine = "";
        currentChar = 0;
        if (currentText > CutsceneText.Length - 1)
        {
            DeActivate();
        }
        fullDialogueLine = CutsceneText[currentText];
        currentText++;
    }

    IEnumerator DelayBeforeText()
    {
        yield return new WaitForSeconds(1f);
        currentText = 0;
        ui.chatPanel.SetActive(true);
        fullDialogueLine = CutsceneText[currentText];
        SetNPCNameAndText();
        activated = true;
    }
}
