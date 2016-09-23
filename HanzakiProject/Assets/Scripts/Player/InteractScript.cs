//InteractScript by Jordi

using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour
{
    public enum InteractType
    {
        OnTrigger,
        OnInput
    };

    public UIManager ui;

    public InteractType interactType;
    public GameObject linkedObject;
    CutsceneController _cutsceneController;

    public float coolDown;
    public bool startCoolDown;
    public string interactText;

    void Awake()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _cutsceneController = GetComponent<CutsceneController>();
    }

    void Update()
    {
        if(startCoolDown)
        {
            coolDown -= Time.deltaTime;
            if(coolDown < 0)
            {
                startCoolDown = false;
                coolDown = 0;
            }
        }
    }

    public void Activate()
    {
        if (!linkedObject.GetComponent<Activate>().activated && coolDown <= 0)
        {
            linkedObject.GetComponent<Activate>().FocusCamera();
            ui.EnterCutscene();
            _cutsceneController.Activate();
        }
        
    }

    public void DeActivate()
    {
        linkedObject.GetComponent<Activate>().DefocusCamera();
        ui.ExitCutscene();
        coolDown = 1;
        startCoolDown = true;
    }
}
